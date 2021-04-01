using FactorPattern.Interface;
using FactorPattern.PetsModel;

namespace FactorPattern.Creater
{
    class CatsCreator : PetShop
    {
        public override ICatalog FactoryMethod()
        {
            return new Cats();
        }
    }
}
