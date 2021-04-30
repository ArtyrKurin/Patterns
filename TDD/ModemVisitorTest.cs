using ModemSys;
using NUnit.Framework;

namespace TDD
{
    [TestFixture]
    public class ModemVisitorTest
    {
        private UnixModemConfigurator v;
        private HayesModem h;
        private ZoomModem z;
        private ErnieModem e;

        [SetUp]
        public void SetUp()
        {
            v = new UnixModemConfigurator();
            h = new HayesModem();
            z = new ZoomModem();
            e = new ErnieModem();
        }

        [Test]
        public void HayesForUnix()
        {
            h.Accept(v);
            Assert.AreEqual("&s1=4&D=3", h.configurationString);
        }
        [Test]
        public void ZoomFirUnix()
        {
            z.Accept(v);
            Assert.AreEqual("&s1=4&D=3", z.configurationString);
        }

        [Test]
        public void ErnieForUnix()
        {
            e.Accept(v);
            Assert.AreEqual("C is too slow", e.internalPattern);
        }
    }
}
