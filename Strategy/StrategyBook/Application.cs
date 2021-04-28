namespace Strategy.StrategyBook
{
    interface IApplication
    {
        void Init();
        void Idle();
        void CleanUp();
        bool Done();
    }
}
