using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace SlackApiInvated
{
    // rudimentary server sessions
    // allows to keep track of a session spanning multiple HTTP requests between our app and Slack API
    // required to enable state security feature
    // sessions are matched to http requests with a dedicated cookie
    class Sessions
    {
        const string SESSION_COOKIE_NAME = "MYCUSTOMSID";
        const int SESSION_LIFETIME_MINUTES = 30;

        private HashSet<string> SessionSet { get; set; }

        public Sessions()
        {
            SessionSet = new HashSet<string>();
        }

        // tries to continue existing session or start a new session
        // will always start a new session if id is not provided or no existing session with given id is found
        // disables HTTP caching to ensure session cookies are not cached
        // returns the session ID
        public string StartSession(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            // set no-cache in response header
            response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            response.AppendHeader("Pragma", "no-cache");
            response.AppendHeader("Expires", "0");

            // try to restore current session based on session cookie in request
            var sessionCookie = request.Cookies[SESSION_COOKIE_NAME];
            var sid = (sessionCookie == null)
                ? null
                : request.Cookies[SESSION_COOKIE_NAME].Value;

            // start a new session if needed
            if ((sid == null) || (SessionSet.Count == 0) || !SessionSet.Contains(sid))
            {
                // generate new sid
                // will repeat until a unique sid is found
                do
                {
                    sid = GenerateNewSid();
                } while (!SessionSet.Add(sid));
            }

            // add session cookie for current session to response
            var cookie = new Cookie
            {
                Name = SESSION_COOKIE_NAME,
                Value = sid,
                Expires = DateTime.Now.AddMinutes(SESSION_LIFETIME_MINUTES)
            };
            response.Cookies.Add(cookie);

            return sid;
        }

        // generates a new random session ID and returns it        
        private string GenerateNewSid()
        {
            string token = Guid.NewGuid().ToString();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(token);
            return Convert.ToBase64String(plainTextBytes);
        }

        // stop a session
        // removes the given session from the session set and removes the cookie 
        // returns true if successful and false if not (e.g. with an invalid sid)
        public bool StopSession(HttpListenerContext context, string sid)
        {
            // tries to remove session from HashSet and returns true or false
            var success = SessionSet.Remove(sid);

            if (success)
            {
                // remove session cookie by setting it to expire NOW
                var response = context.Response;
                var cookie = new Cookie
                {
                    Name = SESSION_COOKIE_NAME,
                    Value = sid,
                    Expires = DateTime.Now
                };
                response.Cookies.Add(cookie);
            }
            return success;
        }
    }


    // wrapper class for the reponse from the Slack API oauth.access
    class SlackApiResponseOauthAccess
    {
        public string access_token { get; set; }
        public string scope { get; set; }
        public string team_name { get; set; }
        public string team_id { get; set; }
        public string user_id { get; set; }
        public Dictionary<string, string> bot { get; set; }
    }

    // main class that constitutes the actual Oauth service
    // this class is a mini webserver which will listen to HTTP requests and respond in HTML
    class SlackOauthService
    {
        // HTTP service config
        const string URL_PREFIX = "http://*:5000/slacktestapp/";

        // HTTP GET parameters        
        const string URL_PARAM_CODE = "code";
        const string URL_PARAM_ERROR = "error";
        const string URL_PARAM_STATE = "state";

        // Slack config
        const string SLACK_CLIENT_ID = "xxx";
        const string SLACK_CLIENT_SECRET = "yyy";
        const string SLACK_SCOPE = "bot";
        const string SLACK_REDIRECT_URL = "zzz";

        // session        
        private Sessions Sessions = new Sessions();

        // sets the html output for a response
        public static void SetHtmlOutput(HttpListenerResponse response, string html)
        {
            // Get a response stream and write the response to it.                        
            response.ContentType = "text/html; charset=utf-8";
            html = "<!DOCTYPE html><html lang=\"en\"><head></head><body>"
                + html + "</body></html>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(html);
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        // builds and returns a query string from a dictionary        
        public static string HttpBuildQuery(Dictionary<string, string> query)
        {
            var queryStringEncoded = "";
            var first = true;
            foreach (var item in query)
            {
                if (!first) queryStringEncoded += "&";
                else first = false;

                queryStringEncoded += item.Key + "=" + WebUtility.UrlEncode(item.Value);
            }

            return queryStringEncoded;
        }

        // creates a md5 hash from a string
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        // return the Slack login URL
        protected string GetSlackLoginUrl(string sid)
        {
            var query = new Dictionary<string, string>
            {
                ["client_id"] = SLACK_CLIENT_ID,
                ["scope"] = SLACK_SCOPE,
                ["redirect_uri"] = SLACK_REDIRECT_URL,
                ["state"] = CreateMD5(sid)
            };

            return "https://slack.com/oauth/authorize?" + HttpBuildQuery(query);
        }

        // Exchanging a verification code for an access token  
        // returns the API response as SlackOuathResponse object
        public SlackApiResponseOauthAccess SlackOauthAccess(
            string clientId,
            string clientSecret,
            string code
        )
        {
            var parameters = new NameValueCollection
            {
                ["client_id"] = clientId,
                ["client_secret"] = clientSecret,
                ["code"] = code
            };

            var client = new WebClient();
            var responseBytes = client.UploadValues(
                "https://slack.com/api/oauth.access",
                "POST",
                parameters
            );

            var responseJson = Encoding.UTF8.GetString(responseBytes);

            SlackApiResponseOauthAccess oauthReponse =
                JsonConvert.DeserializeObject<SlackApiResponseOauthAccess>(responseJson);

            return oauthReponse;
        }

        // handles one new incoming HTTP request        
        // callback for QueueUserWorkItem 
        // is always run in a new thread
        protected void ProcessRequest(object o)
        {
            var context = o as HttpListenerContext;
            var request = context.Request;
            var response = context.Response;
            var query = request.QueryString;

            // start or continue session
            var sid = Sessions.StartSession(context);

            var loginLinkHtml = "<a href=\""
                + GetSlackLoginUrl(sid)
                + "\">Click here to start authentication</a>";

            // case 1: Show start message when query is empty
            if (!query.AllKeys.Any())
            {
                // output to user
                SetHtmlOutput(response, loginLinkHtml);
            }

            // case 2: Received verification code from Slack API
            else if (query.AllKeys.Contains(URL_PARAM_CODE))
            {
                // check if state from query matches MD5 of current session id
                if (query[URL_PARAM_STATE] != CreateMD5(sid))
                {
                    // States do not match. might be a hacking attempt.                          
                    var html = "<p>Something went wrong. Please try again.</p>" + loginLinkHtml;
                    SetHtmlOutput(response, html);
                }
                else
                {
                    // call Slack API to exchange verification code with token
                    var oauthReponse = SlackOauthAccess(
                            SLACK_CLIENT_ID,
                            SLACK_CLIENT_SECRET,
                            query[URL_PARAM_CODE]
                    );

                    // output to user
                    var html = "<p>Oauth token received:"
                        + oauthReponse.access_token
                        + " from: " + oauthReponse.user_id + "</p>";
                    SetHtmlOutput(response, html);

                    // stop session
                    Sessions.StopSession(context, sid);
                }
            }

            // case 3: User has aborted the auth process or an error occured
            else if (query.AllKeys.Contains(URL_PARAM_ERROR))
            {
                // output to user
                var html = "<p>Authentication was canceled.</p>" + loginLinkHtml;
                SetHtmlOutput(response, html);
            }
            response.Close();
        }

        // start the service
        public void Start()
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("This system is not supported.");
                return;
            }

            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefix.
            listener.Prefixes.Add(URL_PREFIX);

            listener.Start();
            Console.WriteLine("Listening for HTTP requests...");

            // listen to incoming http requests
            // start new thread to handle each request
            while (true)
            {
                ThreadPool.QueueUserWorkItem(ProcessRequest, listener.GetContext());
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                var service = new SlackOauthService();
                service.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception occured: " + ex.Message);
            }
        }
    }
}
