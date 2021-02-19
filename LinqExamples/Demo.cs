using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    public class Demo
    {
        private List<Hero> Heroes = new()
        {
            new Hero
            {
                Name = "Superman",
                PowerLevel = 99.9m,
                Powers = new[] {"flight", "heat vision", "strength"}
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
                Powers = new[] {"flight", "strength", "lasso of truth"}
            },
            new Hero
            {
                Name = "Flash",
                PowerLevel = 78.2m,
                Powers = new[] {"speed", "time travel"}
            },
            new Hero
            {
                Name = "Lex Luthor",
                PowerLevel = 80,
                Powers = new[] {"intelligence"},
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

            // weird resharper thing here...
            var aggregate2 = Heroes.Aggregate(decimal.Zero, (halfTotal, next) => halfTotal += next.PowerLevel/2, d => d);
            Console.WriteLine($"Aggregate 2 {aggregate2}");

            // Count
            var count = Heroes.Count; // Heroes is a list, it has a Count property, use it if available
            Console.WriteLine($"Heroes {count}");

            count = Heroes.AsEnumerable().Count(); // this is enumerable, we don't know the count unless we call it
            // keep in mind that this is a O(n) operation
            Console.WriteLine($"Heroes Enumerable Count {count}");

            // use a predicate - no need for where!
            count = Heroes.Count(h => h.IsVillain);
            Console.WriteLine($"Villains {count}");

            // Max/Min
            var max = Heroes.Max(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {max}");

            max = Heroes.Max(h => h.IsVillain ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {max}");

            var min = Heroes.Min(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {min}");

            min = Heroes.Min(h => h.PowerLevel > 80 ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {min}");

            // Sum
            var sum = Heroes.Sum(h => h.PowerLevel);
            Console.WriteLine($"PowerLevel Sum {sum}");

            // a method group, the variable is assumed
            sum = Heroes.Sum(SumFunction);

            Console.WriteLine($"Heroes PowerLevel {sum}");
        }

        private decimal SumFunction(Hero hero)
        {
            // we could have just put this in our sum function, but what if the logic if logic was more complicated
            return !hero.IsVillain ? hero.PowerLevel : decimal.Zero;
        }

        public void ConversionOperators()
        {
            // cast
            var tempHeroes = new List<IHero>(Heroes);
            
            //only good where your sure that everything is the same type of interface
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

            // neat! does this work with interfaces?
            var villains = mixedList.OfType<Villain>().ToList();
            Console.WriteLine(villains.Count);

            // ToDictionary
            var heroDictionary = Heroes.ToDictionary(h => h.Name);
            Console.WriteLine($"Superman {heroDictionary["Superman"]}");
            heroDictionary.ToList().ForEach(k => Console.WriteLine($"{k.Key}"));

            // readability counts!
            var whereDictionary = Heroes.Where(h => h.PowerLevel > 80)
                .ToDictionary(h => h.Name);
            Console.WriteLine(whereDictionary.Count);

            try
            {
                var badDictionary = Heroes.ToDictionary(h => h.PowerLevel);
                Console.WriteLine(badDictionary.Keys.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }


}