using System;
using StrategyPattern.Strategy;

namespace StrategyPattern.ConcreteStrategy
{
    public class DeepFrying : CookStrategy
    {
        public override void Cook(string food)
        {
            Console.WriteLine($"Cooking {food} by deep frying it.");
        }
    }
}