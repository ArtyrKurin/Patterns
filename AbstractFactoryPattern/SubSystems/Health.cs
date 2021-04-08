namespace AbstractFactoryPattern.SubSystems
{
    public class Health
    {
        public string HealHero()
        {
            var cheackHp = IsHpFull(100);
            if (cheackHp)
            {
                return "Full Hp\n";
            }
            return "Heal Hp\n";
        }

        public bool IsHpFull(int hp)
        {
            if (hp == 100)
            {
                return true;
            }
            return false;
        }
    }
}
