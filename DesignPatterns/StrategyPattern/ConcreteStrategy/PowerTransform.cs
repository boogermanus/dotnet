using System;
using System.Collections.Generic;
using StrategyPattern.Strategy;

namespace StrategyPattern.ConcreteStrategy
{
    public class PowerTransform : ListTransformStrategy
    {
        private int _power = 1;

        public PowerTransform(int power)
        {
            _power = power;
        }

        public override List<int> Transform(List<int> list)
        {
            var value = new List<int>();

            foreach(var item in list)
            {
                value.Add((int)Math.Pow((double)item, (double)_power));
            }

            return value;
        }
    }
}