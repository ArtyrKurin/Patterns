using ModemSys.Interface;

namespace ModemSys
{
    public class UnixModemConfigurator : IHayesModemVisitor, IZoomModemVisitor, IErnieModemVisitor
    {
        public void Visit(HayesModem m)
        {
            m.configurationString = "&s1=4&D=3";
        }

        public void Visit(ErnieModem m)
        {
            m.configurationString = 42;
        }

        public void Vizit(ZoomModem m)
        {
            m.configurationString = 42;
        }
    }
}
