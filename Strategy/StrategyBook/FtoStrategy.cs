using System;
using System.IO;

namespace Strategy.StrategyBook
{
    public class FtoStrategy : IApplication
    {
        private TextReader input;
        private TextWriter output;
        private bool isDone = false;
        public void CleanUp()
        {
            Console.WriteLine("ftoc exit");
        }

        public bool Done()
        {
            return isDone;
        }

        public void Idle()
        {
            string fahrString = Console.ReadLine();
            if (fahrString == null || fahrString.Length == 0)
            {
                Done();
            }
            else
            {
                double fahr = Double.Parse(fahrString);
                double celcius = 5.0 / 9.0 * (fahr - 32);
                Console.WriteLine("F={0}, C={1}", fahr, celcius);
            }
        }

        public void Init()
        {
            input = Console.In;
            output = Console.Out;
        }
    }
}
