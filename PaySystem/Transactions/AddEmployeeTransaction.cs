namespace PaySystem
{
    public class AddEmployeeTransaction : ITransaction
    {
        private readonly int _empid;
        private readonly string _name;
        private readonly string _address;

        public AddEmployeeTransaction(int empid, string name, string address)
        {
            _empid = empid;
            _name = name;
            _address = address;
        }

        protected abstract PaymentClassification MakeClassification();
        protected abstract PaymentScheduel MakeSchedule();

        public void Execute()
        {
            PaymentClassification pc = MakeClassification();
            PaymentScheduel ps = MakeSchedule();
            PaymentMethod pm = new HoldMethod();

            Employee emp = new Employee(_empid, _name, _address);
            emp.Classification = pc;
            emp.Schedule = ps;
            emp.Method = pm;
            PayRollDatabase.AddEmployee(empid, emp);
        }
    }
}
