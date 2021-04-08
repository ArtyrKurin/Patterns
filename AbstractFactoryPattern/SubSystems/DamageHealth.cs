namespace AbstractFactoryPattern.SubSystems
{
    public class DamageHealth
    {
        public string Damage()
        {
            return "Damage: Hero!\n";
        }

        public string Miss()
        {
            return "Damage: Miss!\n";
        }
    }
}
