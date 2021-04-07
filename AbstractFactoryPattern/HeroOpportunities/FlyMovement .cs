using AbstractFactoryPattern.Abstracts;
using System;

namespace AbstractFactoryPattern.HeroOpportunities
{
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
}
