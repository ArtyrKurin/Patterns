using FactorPattern.Interface;
using FactorPattern.PetsModel;

namespace FactorPattern.Creater
{
    class DogsCreator : PetShop
    {
        public override ICatalog FactoryMethod()
        {
            return new Dogs();
        }
    }
}
