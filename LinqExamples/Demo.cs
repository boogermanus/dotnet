using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    public class Demo
    {
        public List<Hero> Heroes = new List<Hero>
        {
            new Hero
            {
                Name = "Superman",
                PowerLevel = 99.9m,
                Powers = new string[] {"flight", "heat vision", "strength"}
            },
            new Hero
            {
                Name = "Batman",
                PowerLevel = 99.9m,
                Powers = new string[0],
            },
            new Hero
            {
                Name = "Wonder Women",
                PowerLevel = 89,
                Powers = new string[] {"flight", "strength", "lasso of truth"}
            },
            new Hero
            {
                Name = "Flash",
                PowerLevel = 78.2m,
                Powers = new string[] {"speed", "time travel"}
            },
            new Hero
            {
                Name = "Lex Luthor",
                PowerLevel = 80,
                Powers = new string[] {"intelligence"},
                IsVillain = true
            },
            new Hero
            {
                Name = "The Joker",
                PowerLevel = 71.2m,
                Powers = new string[0],
                IsVillain = true
            }
        };

        public void AggregationOperators()
        {
            // Aggregate
            var aggregate1 = Heroes.Aggregate(string.Empty, 
                (longest, next) => next.Name.Length > longest.Length ? next.Name : longest, h => h.ToUpper());
            Console.WriteLine($"Aggregate 1: {aggregate1}");

            var aggregate2 = Heroes.Aggregate(decimal.Zero, (sum, next) => sum += next.PowerLevel/2, d => d);
            Console.WriteLine($"Aggregate 2 {aggregate2}");

            // Count
            var count = Heroes.Count(); // no need to do this unless you're working with IEnumerable
            count = Heroes.Count;
            Console.WriteLine($"Heroes {count}");

            count = Heroes.Count(h => h.IsVillain);
            Console.WriteLine($"Villains {count}");

            // Max/Min
            var max = Heroes.Max(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {max}");

            max = Heroes.Max(h => h.IsVillain ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {max}");

            var min = Heroes.Min(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {min}");

            min = Heroes.Min(h => !h.IsVillain ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {min}");

            // Sum
            var sum = Heroes.Sum(h => h.PowerLevel);
            Console.WriteLine($"PowerLevel Sum {sum}");

            sum = Heroes.Sum(SumFunction);

            Console.WriteLine($"Heroes PowerLevel {sum}");
        }

        private decimal SumFunction(Hero hero)
        {
            return !hero.IsVillain ? hero.PowerLevel : decimal.Zero;
        }

        public void ConversionOperators()
        {
            // cast
            List<IHero> tempHeroes = new List<IHero>(Heroes);

            var heroObjects = tempHeroes.Cast<Hero>().ToList();
            heroObjects.ForEach(Console.WriteLine);

            // OfType
            List<IHero> mixedList = new List<IHero>(Heroes);
            mixedList.Add(new Villain
            {
                Name = "Captain Cold",
                Hero = "Flash"
            });
            mixedList.Add(new Villain
            {
                Name = "Doomsday",
                Hero = "Superman"
            });

            var villains = mixedList.OfType<Villain>().ToList();
            Console.WriteLine(villains.Count);

            // ToDictionary
            var heroDictionary = Heroes.ToDictionary(h => h.Name);
            Console.WriteLine($"Superman {heroDictionary["Superman"]}");
        }
    }


}