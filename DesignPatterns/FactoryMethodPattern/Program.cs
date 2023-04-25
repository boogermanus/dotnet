using System;
using System.Collections.Generic;
using FactoryMethodPattern.ConcreteCreator;
using FactoryMethodPattern.Creator;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // old and busted
            SandwichFactory();

            // new hotness
            HeroFactory();
        }

        private static void SandwichFactory()
        {

            List<Sandwich> sandwiches = new List<Sandwich>
            {
                new SpicyTurkey(),
                new HamSandwich()
            };

            sandwiches.ForEach(s => {
                Console.WriteLine($"Sandwich: {s.Name}");
                
                s.Ingredients.ForEach(i => Console.WriteLine($"\tIngredient: {i.Name}") );
            });

            Console.ReadKey();
        }

        private static void HeroFactory()
        {
            var justiceLeague = new List<Hero>
            {
                new Superman(),
                new Batman(),
                new WonderWomen(),
                new Flash()
            };

            justiceLeague.ForEach(jlm => Console.WriteLine(jlm));
        }
    }
}
