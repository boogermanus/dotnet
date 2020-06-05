using System;
using StrategyPattern.Strategy;

namespace StrategyPattern.ConcreteStrategy
{
    public class Grilling : CookStrategy
    {
        public override void Cook(string food)
        {
            Console.WriteLine($"Cooking {food} by grilling it.");
        }
    }
}