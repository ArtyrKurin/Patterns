using NUnit.Framework;

namespace TDD
{

    public class PeyrollTest
    {
        [Test]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", emp.Name);

            PaymentClassification pc = emp.Classification;
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification sc = pc as SalariedClassification;

            PaymentSchedule ps = emp.Schedule;

            PaymentMethod pm = emp.Method;
        }
    }
}
