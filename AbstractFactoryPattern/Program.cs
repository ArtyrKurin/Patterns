using AbstractFactoryPattern.Factory;
using AbstractFactoryPattern.GenericCreateHero;
using AbstractFactoryPattern.HeroClient;
using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = MyHeroFactory<ElfFactory>.Create();
            elf.Hit();
            elf.Run();

            Hero voin = MyHeroFactory<VoinFactory>.Create();
            voin.Hit();
            voin.Run();

            Console.ReadLine();
        }
    }
}
