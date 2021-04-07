using AbstractFactoryPattern.Abstracts;
using AbstractFactoryPattern.HeroOpportunities;

namespace AbstractFactoryPattern.Factory
{
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
}
