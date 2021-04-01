using FactorPattern.Creater;
using System;

namespace FactorPattern
{
    public class User
    {

        public void Main()
        {
            Console.WriteLine("Cats: ");
            ClientCode(new CatsCreator());

            Console.WriteLine("");

            Console.WriteLine("Dogs:");
            ClientCode(new DogsCreator());
        }

        // Клиентский код работает с экземпляром конкретного создателя, хотя и
        // через его базовый интерфейс. Пока клиент продолжает работать с
        // создателем через базовый интерфейс, вы можете передать ему любой
        // подкласс создателя.
        public void ClientCode(PetShop creator)
        {
            // ...
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.ShopCatalog());
            // ...
        }

    }
}
