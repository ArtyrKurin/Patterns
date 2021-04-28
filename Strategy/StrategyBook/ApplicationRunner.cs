namespace Strategy.StrategyBook
{
    public class ApplicationRunner
    {
        private IApplication itsApplication = null;
        public void run()
        {
            itsApplication.Init();
            while (!itsApplication.Done())
                itsApplication.Idle();
            itsApplication.CleanUp();
        }
    }
}
