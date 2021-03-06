namespace PaySystem
{
    public class AddSalariedEmployee
    {
        private readonly double salary;
        public AddSalariedEmployee(int id, string name, string address, double salary) : base(id, name, address)
        {
            this.salary = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new SalariedClassification(salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
