using AbstractFactoryPattern.Abstracts;
using System;

namespace AbstractFactoryPattern.HeroOpportunities
{
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
}
