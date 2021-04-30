using System;

namespace ModemSys
{
    public class HayesModem : IModem
    {
        public string configurationString = null;
        public void Accept(ModemVisitor v)
        {
            try
            {
                HayesModem hv = (HayesVisitor)v;
                hv.Visit(this);
            }
            catch (InvalidCastException e) { }
        }

        private void Visit(HayesModem hayesModem)
        {
            throw new NotImplementedException();
        }

        public void Dial(string pno)
        {

        }

        public void Hangup()
        {

        }

        public char Recv()
        {
            return (char)0;
        }

        public void Send(char c)
        {

        }
    }
}
