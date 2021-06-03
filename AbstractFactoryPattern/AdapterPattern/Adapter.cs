using AbstractFactoryPattern.InterfacesAdapter;

namespace AbstractFactoryPattern.AdapterPattern
{
    public class Adapter : IInfoAdapter
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.HeroInfo()}'";
        }
    }
}
