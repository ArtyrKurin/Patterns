namespace ModemSys
{
    public interface IModem
    {
        void Dial(string pno);
        void Hangup();
        void Send(char c);
        char Recv();
        void Accept(ModemVisitor v);
    }
}
