using System;
using StrategyPattern.Strategy;

namespace StrategyPattern.Context
{
    public class CookingMethod
    {
        private string _food;
        private CookStrategy _cookingStrategy;

        public void SetCookingStrategy(CookStrategy cookStrategy)
        {
            _cookingStrategy = cookStrategy;
        }

        public void SetFood(string food)
        {
            _food = food;
        }

        public void Cook()
        {
            _cookingStrategy.Cook(_food);
            Console.WriteLine();
        }
    }
}