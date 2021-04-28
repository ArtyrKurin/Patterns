using System;

namespace Command
{
    public class SleepCommand : ICommand
    {
        private ICommand wakeUpCommand = null;
        private ActiveObjectEngine engine = null;
        private long sleepTime = 0;
        private DateTime startTime;
        private bool started;

        public SleepCommand(long milliseconds, ActiveObjectEngine objectEngine, ICommand wakeUpcommand)
        {
            sleepTime = milliseconds;
            engine = objectEngine;
            this.wakeUpCommand = wakeUpCommand;
        }

        public void Excute()
        {
            DateTime currentTime = DateTime.Now;
            if (!started)
            {
                started = true;
                startTime = currentTime;
                engine.AddCommand(this);
            }
            else
            {
                TimeSpan elapsedTime = currentTime - startTime;
                if (elapsedTime.TotalMilliseconds < sleepTime)
                {
                    engine.AddCommand(this);
                }
                else
                {
                    engine.AddCommand(wakeUpCommand);
                }
            }
        }
    }
}
