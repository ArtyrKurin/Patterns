using System;

namespace AbstractFactoryPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Facade
            //DamageHealth damage = new DamageHealth();
            //Health health = new Health();
            //Facade facade = new Facade(damage, health);
            ////AbstractFactory
            //Hero elf = MyHeroFactory<ElfFactory>.Create();
            ////AbstractFactory Method
            //elf.Hit();
            //// Facade Method
            //Console.WriteLine(facade.Operation2());
            ////AbstractFactory Method
            //elf.Run();

            //Hero voin = MyHeroFactory<VoinFactory>.Create();
            //voin.Hit();
            //voin.Run();
            //Console.WriteLine(facade.Operation1());



            //Adaptee adaptee = new Adaptee();
            //IInfoAdapter target = new Adapter(adaptee);
            //Console.WriteLine("Adapter Pattern");
            //Console.WriteLine(target.GetRequest());
            int i = 5; object o = i; long j = (long)o;
            Console.ReadLine();
        }
    }
}
