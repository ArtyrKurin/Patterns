using System;

namespace Command
{
    public class Program : ICommand
    {
        private long itsDelay;
        private char itsChar;
        private static bool stop = false;
        private static ActiveObjectEngine engine = new ActiveObjectEngine();
        public Program(long delay, char c)
        {
            itsDelay = delay;
            itsChar = c;
        }
        private class StopCommand : ICommand
        {
            public void Excute()
            {
                Program.stop = true;
            }
        }

        static void Main(string[] args)
        {
            engine.AddCommand(new Program(1, '1'));
            engine.AddCommand(new Program(3, '3'));
            engine.AddCommand(new Program(5, '5'));
            engine.AddCommand(new Program(7, '7'));
            ICommand stopCommand = new StopCommand();
            engine.AddCommand(new SleepCommand(10000, engine, stopCommand));
            engine.Run();
        }

        public void Excute()
        {
            Console.Write(itsChar);
            if (!stop)
            {
                DelayAndRepeat();
            }
        }
        private void DelayAndRepeat()
        {
            engine.AddCommand(new SleepCommand(itsDelay, engine, this));
        }
    }
}
