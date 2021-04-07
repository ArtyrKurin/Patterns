using AbstractFactoryPattern.Abstracts;
using AbstractFactoryPattern.HeroOpportunities;

namespace AbstractFactoryPattern.Factory
{
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
}
