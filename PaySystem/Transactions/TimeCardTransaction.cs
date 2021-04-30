using System;

namespace PaySystem.Transactions
{
    public class TimeCardTransaction : ITransaction
    {
        private readonly DateTime _date;
        private readonly double _hourse;
        private readonly int _empId;

        public TimeCardTransaction(DateTime date, double hours, int empId)
        {
            _date = date;
            _hourse = hours;
            _empId = empId;
        }

        public void Execute()
        {
            Employee employee = PayRollDatabase.GetEmloyee(_empId);
            if (employee != null)
            {
                HourlyClassification hc = employee.Classification as HourlyClassification;
                if (hc != null)
                {
                    hc.AddTimeCard(new TimeCard(_date, _hourse)));
                }
                else
                {
                    throw new InvalidOperationException("Попытка добавить карточку табельного учёта" +
                        "для работника не на почасовой оплате");
                }
            }
            else
            {
                throw new InvalidOperationException("Работник не найден");
            }
        }
    }
}
