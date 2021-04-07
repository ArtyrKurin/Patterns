using AbstractFactoryPattern.Abstracts;
using System;

namespace AbstractFactoryPattern.HeroOpportunities
{
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
}
