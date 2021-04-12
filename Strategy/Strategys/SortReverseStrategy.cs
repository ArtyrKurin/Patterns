using Strategy.Interface;
using System.Collections.Generic;

namespace Strategy.Strategys
{
    class SortReverseStrategy : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }
}
