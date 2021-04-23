using Proxy.Interface;
using Proxy.Subjects;
using System;

namespace Proxy
{
    public class Client
    {
        // Клиентский код должен работать со всеми объектами (как с реальными,
        // так и заместителями) через интерфейс Субъекта, чтобы поддерживать как
        // реальные субъекты, так и заместителей. В реальной жизни, однако,
        // клиенты в основном работают с реальными субъектами напрямую. В этом
        // случае, для более простой реализации паттерна, можно расширить
        // заместителя из класса реального субъекта.
        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}
