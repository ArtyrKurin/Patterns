using PaySystem.Transactions;

namespace PaySystem
{
    public class Employee
    {
        private int empid;
        private string name;
        private string address;

        public Employee(int empid, string name, string address)
        {
            this.empid = empid;
            this.name = name;
            this.address = address;
        }

        internal UnionAffiliation Affiliation { get; set; }
    }
}