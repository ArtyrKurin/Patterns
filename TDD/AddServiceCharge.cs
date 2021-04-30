using NUnit.Framework;
using PaySystem;
using System;

namespace TDD
{
    [TestFixture]
    class AddServiceCharge
    {
        public void AddServiceCharge()
        {
            int empId = 2;
            AddHourlyEmployee hourlyEmployee = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            hourlyEmployee.Execute();

            Employee employee = PayRollDatabase.GetEmloyee(empId);
            UnionAffiliation af = new UnionAffiliation();
            employee.Affiliation = af;
            int memberId = 86;
            PayRollDatabase.AddUnionMember(memberId, employee);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2005, 8, 8), 12.95);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge(new DateTime(2005, 8, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }
    }
}
