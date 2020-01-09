using System;
using System.Collections.Generic;
using Sandwiches;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sandwich> sandwiches = new List<Sandwich>
            {
                new SpicyTurkey(),
                new HamSandwich()
            };

            foreach(var sandwich in sandwiches)
            {
                Console.WriteLine($"Sandwich: {sandwich.Name}");
                foreach(var ingredient in sandwich.Ingredients)
                {
                    Console.WriteLine($"Ingredient: {ingredient.Name}");
                }
            }

            Console.ReadKey();
        }
    }
}
