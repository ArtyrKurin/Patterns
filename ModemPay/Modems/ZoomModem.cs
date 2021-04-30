using System;

namespace ModemSys
{
    public class ZoomModem : IModem
    {
        public string iternalPattern = null;
        public int configurationString = 0;
        public void Accept(ModemVisitor v)
        {
            v.Visit(this);
        }

        public void Dial(string pno)
        { }

        public void Hangup()
        { }

        public char Recv()
        {
            return (char)0;
        }

        public void Send(char c)
        {
            throw new NotImplementedException();
        }
    }
}
