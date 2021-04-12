using Strategy.Interface;
using System.Collections.Generic;

namespace Strategy.Strategys
{
    public class PopStrategy : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Remove("a");
            return list;
        }
    }
}
