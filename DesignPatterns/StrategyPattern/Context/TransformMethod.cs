using System;
using System.Collections.Generic;
using StrategyPattern.Strategy;

namespace StrategyPattern.Context
{
    public class TransformMethod
    {
        private List<int> _list;
        private ListTransformStrategy _strategy;

        public void SetStrategy(ListTransformStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetList(List<int> list)
        {
            _list = list;
        }

        public List<int> Transform()
        {
            return _strategy.Transform(_list);
        }
    }
}