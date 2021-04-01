using FactorPattern.Interface;

namespace FactorPattern.PetsModel
{
    public class Cats : ICatalog
    {
        public string Operation()
        {
            return "Cats Food";
        }
    }
}
