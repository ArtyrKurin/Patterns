using AbstractFactoryPattern.Abstracts;
using AbstractFactoryPattern.HeroClient;

namespace AbstractFactoryPattern.GenericCreateHero
{
    internal class MyHeroFactory<T> where T : HeroFactory, new()
    {
        internal static Hero Create()
        {
            return new Hero(new T());
        }
    }
}
