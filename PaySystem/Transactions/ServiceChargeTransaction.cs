using System;

namespace PaySystem.Transactions
{
    public class ServiceChargeTransaction : ITransaction
    {
        private readonly int _memberId;
        private readonly DateTime _time;
        private readonly double _charge;

        public ServiceChargeTransaction(int Id, DateTime time, double charge)
        {
            _memberId = Id;
            _time = time;
            _charge = charge;
        }

        public void Execute()
        {
            Employee emp = PayRollDatabase.GetUnionMember(_memberId);
            if (emp != null)
            {
                UnionAffiliation ua = null;
                if (emp.Affiliation is UnionAffiliation)
                {
                    ua = emp.Affiliation as UnionAffiliation;
                }
                if (ua != null)
                {
                    ua.AddServiceCharge(new ServiceCharge(_time, _charge));
                }
                else
                {
                    throw new InvalidOperationException("Попытка добавить плату за услуги для члена" +
                        "профсоюза с незарегистрированным членством");
                }
            }
            else
            {
                throw new InvalidOperationException("Член профсоюза не найден.");
            }
        }
    }
}
