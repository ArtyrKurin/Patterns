using System;
using System.IO;

namespace Fto
{
    public class TemplateMethod : Application
    {
        private TextReader input;
        private TextWriter output;
        public static void Main(string[] args)
        {
            new TemplateMethod().Run();
        }
        protected override void Cleanup()
        {
            output.WriteLine("ftoc exit");
        }

        protected override void Idle()
        {
            string fahrString = Console.ReadLine();
            if (fahrString == null || fahrString.Length == 0)
            {
                SetDone();
            }
            else
            {
                double fahr = Double.Parse(fahrString);
                double celcius = 5.0 / 9.0 * (fahr - 32);
                Console.WriteLine("F={0}, C={1}", fahr, celcius);
            }
        }

        protected override void Init()
        {
            input = Console.In;
            output = Console.Out;
        }
    }
}
