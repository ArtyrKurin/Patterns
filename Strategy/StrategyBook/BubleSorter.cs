namespace Strategy.StrategyBook
{
    public class BubleSorter
    {
        private int operations = 0;
        private int length = 0;
        private IntSortHandler itsSortHandler = null;
        public BubleSorter(IntSortHandler handler)
        {
            itsSortHandler = handler;
        }
        public int Sort(object array)
        {
            itsSortHandler.SetArray(array);
            length = itsSortHandler.Length();
            operations = 0;
            if (length <= 1)
            {
                return operations;
            }
            for (int nextToLast = 0; nextToLast < length - 2; nextToLast++)
            {
                for (int index = 0; index < nextToLast; index++)
                {
                    if (itsSortHandler.OutOfOrder(index))
                        itsSortHandler.Swap(index);
                    operations++;
                }
            }
            return operations;
        }
    }
}
