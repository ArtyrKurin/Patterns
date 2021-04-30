using System;
using System.Collections;

namespace PaySystem
{
    public class PayRollDatabase
    {
        private static Hashtable employess = new Hashtable();
        public static void AddEmployee(int id, Employee employee)
        {
            employess[id] = employee;
        }
        public static Employee GetEmloyee(int id)
        {
            return employess[id] as Employee;
        }

        internal static void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        internal static Employee GetUnionMember(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
