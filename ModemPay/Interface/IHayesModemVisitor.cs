namespace ModemSys.Interface
{
    public interface IHayesModemVisitor : IModemInterface
    {
        void Visit(ErnieModem m);
    }
}
