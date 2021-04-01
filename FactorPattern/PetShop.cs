using FactorPattern.Interface;

namespace FactorPattern
{
    public abstract class PetShop
    {
        public abstract ICatalog FactoryMethod();
        public string ShopCatalog()
        {
            var animal = FactoryMethod();
            var result = "Catalog: " + animal.Operation() + "\n";

            return result;
        }
    }
}
