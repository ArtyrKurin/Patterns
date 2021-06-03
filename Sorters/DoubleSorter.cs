namespace Sorters
{
    public class DoubleSorter : BubleSorter
    {
        private double[] array = null;

        public int Sort(double[] theArray)
        {
            array = theArray;
            length = array.Length;
            return DoSort();
        }

        protected override bool OutIfOrder(int index)
        {
            return array[index] > array[index + 1];
        }

        protected override void Swap(int index)
        {
            double temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }
    }
}
