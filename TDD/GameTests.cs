using Learning;
using NUnit.Framework;

namespace TDD
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void TestOneThrow()
        {
            Game game = new Game();
            game.Add(5);
            Assert.AreEqual(5, game.Score);
        }
    }
}
