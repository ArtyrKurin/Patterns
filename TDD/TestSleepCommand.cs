using Command;
using NUnit.Framework;
using System;

namespace TDD
{
    [TestFixture]
    public class TestSleepCommand
    {
        private class WakeUpCommand : Command.ICommand
        {
            public bool executed = false;

            public void Excute()
            {
                executed = true;
            }
        }
        [Test]
        public void TestSleep()
        {
            WakeUpCommand wakeUp = new WakeUpCommand();
            ActiveObjectEngine objectEngine = new ActiveObjectEngine();
            SleepCommand sleep = new SleepCommand(1000, objectEngine, wakeUp);
            objectEngine.AddCommand(sleep);
            DateTime start = DateTime.Now;
            objectEngine.Run();
            DateTime stop = DateTime.Now;
            double sleepTime = (stop - start).TotalMilliseconds;
            Assert.IsTrue(sleepTime >= 1000, "SleepTime " + sleepTime + " exepcted > 1000");
            Assert.IsTrue(sleepTime <= 1100, "SleepTime " + sleepTime + " exepcted < 1100");
            Assert.IsTrue(wakeUp.executed, "Command Executed");
        }
    }
}
