using System.Collections.Generic;

namespace StrategyPattern.Strategy
{
    public abstract class ListTransformStrategy
    {
        public abstract List<int> Transform(List<int> list);
    }
}