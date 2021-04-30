namespace PaySystem.Transactions
{
    public class DeleteEmployeeTransaction : ITransaction
    {
        private readonly int id;

        public DeleteEmployeeTransaction(int Id)
        {
            id = Id;
        }
        public void Execute()
        {
            PayRollDatabase.DeleteEmployee(id);
        }
    }
}
