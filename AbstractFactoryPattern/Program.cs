using AbstractFactoryPattern.FacadeClient;
using AbstractFactoryPattern.Factory;
using AbstractFactoryPattern.GenericCreateHero;
using AbstractFactoryPattern.HeroClient;
using AbstractFactoryPattern.SubSystems;
using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Facade
            DamageHealth damage = new DamageHealth();
            Health health = new Health();
            Facade facade = new Facade(damage, health);
            //AbstractFactory
            Hero elf = MyHeroFactory<ElfFactory>.Create();
            //AbstractFactory Method
            elf.Hit();
            // Facade Method
            Console.WriteLine(facade.Operation2());
            //AbstractFactory Method
            elf.Run();

            Hero voin = MyHeroFactory<VoinFactory>.Create();
            voin.Hit();
            voin.Run();
            Console.WriteLine(facade.Operation1());

            Console.ReadLine();
        }
    }
}
