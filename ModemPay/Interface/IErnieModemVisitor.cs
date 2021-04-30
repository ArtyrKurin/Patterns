namespace ModemSys.Interface
{
    public interface IErnieModemVisitor : IModemInterface
    {
        void Visit(ErnieModem m);
    }
}
