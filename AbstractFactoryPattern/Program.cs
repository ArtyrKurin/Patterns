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
            DamageHealth damage = new DamageHealth();
            Health health = new Health();
            Facade facade = new Facade(damage, health);
            Hero elf = MyHeroFactory<ElfFactory>.Create();
            elf.Hit();
            Console.WriteLine(facade.Operation2());
            elf.Run();

            Hero voin = MyHeroFactory<VoinFactory>.Create();
            voin.Hit();
            voin.Run();
            Console.WriteLine(facade.Operation1());

            Console.ReadLine();
        }
    }
}
