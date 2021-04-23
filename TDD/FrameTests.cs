using Learning;
using NUnit.Framework;

namespace TDD
{
    [TestFixture]
    public class FrameTests
    {
        [Test]
        public void TestScoreNoThrows()
        {
            Frame frame = new Frame();
            Assert.AreEqual(0, frame.Score);
        }
    }
}