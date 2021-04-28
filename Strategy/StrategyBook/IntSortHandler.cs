namespace Strategy.StrategyBook
{
    public class IntSortHandler : ISortHandler
    {
        private int[] array = null;
        public void Swap(int index)
        {
            int temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }

        public void SetArray(object array)
        {
            this.array = (int[])array;
        }

        public int Length()
        {
            return array.Length;
        }
        public bool OutOfOrder(int index)
        {
            return (array[index] > array[index + 1]);
        }
    }
}
