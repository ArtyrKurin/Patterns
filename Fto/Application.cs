namespace Fto
{
    public abstract class Application
    {
        private bool isDone = false;
        protected abstract void Init();
        protected abstract void Idle();
        protected abstract void Cleanup();

        protected void SetDone()
        {
            isDone = true;
        }

        protected bool Done()
        {
            return isDone;
        }

        public void Run()
        {
            Init();
            while (!Done())
                Idle();
            Cleanup();
        }
    }
}
