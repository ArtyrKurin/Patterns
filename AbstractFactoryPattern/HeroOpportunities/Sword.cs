using AbstractFactoryPattern.Abstracts;
using System;

namespace AbstractFactoryPattern.HeroOpportunities
{
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }
}
