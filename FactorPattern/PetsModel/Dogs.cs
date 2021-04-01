using FactorPattern.Interface;

namespace FactorPattern.PetsModel
{
    public class Dogs : ICatalog
    {
        public string Operation()
        {
            return "Dogs Food";
        }
    }
}
