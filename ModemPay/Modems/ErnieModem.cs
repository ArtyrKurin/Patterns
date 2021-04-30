using System;

namespace ModemSys
{
    public class ErnieModem : IModem
    {
        public string internalPattern = null;

        public int configurationString = 0;
        public void Accept(IModemVisitor v)
        {
            v.Visit(this);
        }

        public void Accept(ModemVisitor v)
        {
            if (v is ErnieModemVisitor)
                v as ErnieModemVisitor).Visit(this);
        }

        public void Dial(string pno)
        {
            throw new NotImplementedException();
        }

        public void Hangup()
        {
            throw new NotImplementedException();
        }

        public char Recv()
        {
            return (char)0;
        }

        public void Send(char c)
        {
            throw new NotImplementedException();
        }
    }
}
