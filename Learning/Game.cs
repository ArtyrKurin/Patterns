namespace Learning
{
    public class Game
    {
        private int currentFrame = 0;
        private bool IsFistThrow = true;
        private Scorer scorer = new Scorer();

        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        public int Score
        {
            get { return ScoreForFrame(currentFrame); }
        }
        private bool Strike(int pins)
        {
            return (IsFistThrow && pins == 10);
        }
        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!IsFistThrow);
        }
        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }
        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
            {
                AdvanceFrame();
            }
            else
            {
                IsFistThrow = false;
            }
        }
        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
            {
                currentFrame = 10;
            }
        }
        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }
    }
}
