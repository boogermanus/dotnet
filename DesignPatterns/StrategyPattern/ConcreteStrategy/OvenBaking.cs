using System;
using StrategyPattern.Strategy;

namespace StrategyPattern.ConcreteStrategy
{
    public class OvenBaking : CookStrategy
    {
        public override void Cook(string food)
        {
            Console.WriteLine($"Cooking {food} by oven baking it.");
        }
    }
}