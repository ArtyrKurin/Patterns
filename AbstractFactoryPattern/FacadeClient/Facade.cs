using AbstractFactoryPattern.SubSystems;

namespace AbstractFactoryPattern.FacadeClient
{
    public class Facade
    {
        public DamageHealth DamageHealth;
        public Health Health;

        public Facade(DamageHealth subsystem1, Health subsystem2)
        {
            this.DamageHealth = subsystem1;
            this.Health = subsystem2;
        }

        // Методы Фасада удобны для быстрого доступа к сложной функциональности
        // подсистем. Однако клиенты получают только часть возможностей
        // подсистемы.
        public string Operation1()
        {

            string result = "Facade orders subsystems to perform the action:\n";
            result += DamageHealth.Miss();
            result += Health.HealHero();
            return result;
        }

        public string Operation2()
        {
            string result = "Facade orders subsystems to perform the action:\n";
            result += DamageHealth.Damage();
            result += Health.HealHero();
            return result;
        }
    }
}
