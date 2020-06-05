using System.Collections.Generic;
using StrategyPattern.Strategy;

namespace StrategyPattern.ConcreteStrategy
{
    public class DoubleTransform : ListTransformStrategy
    {
        public override List<int> Transform(List<int> list)
        {
            var value = new List<int>();

            foreach(var item in list)
            {
                value.Add(item * 2);
            }

            return value;
        }
    }
}