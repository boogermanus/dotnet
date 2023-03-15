using System;
using System.Linq;
using LinqExamples.Models;
namespace LinqExamples.Demos
{
    public class AggregationDemo : DemoBase
    {
        public override void Run()
        {
            // Aggregate - get the longest name.
            var aggregate1 = Heroes.Aggregate(string.Empty,
                (longest, next) => next.Name.Length > longest.Length ? next.Name : longest, h => h.ToUpper());
            Console.WriteLine($"Aggregate 1: {aggregate1}");

            // Aggregate join - join all the heroes by ','
            var aggregateJoin = Heroes.Aggregate(string.Empty,
                (current, next) => current + (current.Length == 0 ? string.Empty : ",") + next);
            Console.WriteLine(aggregateJoin);

            // aggregate join again - join all the heroes names by ',', but split by ','
            // basically string.join...
            var aggregateJoinWithSplit =
                Heroes.Aggregate(string.Empty,
                    (current, next) => current + (current.Length == 0 ? string.Empty : ",") + next.Name,
                    d => d.Split(",")).ToList();
            aggregateJoinWithSplit.ForEach(Console.WriteLine);

            // take half of the power of everyone, and then divide it by two.
            var aggregate2 = Heroes.Aggregate(decimal.Zero, (halfTotal, next) => halfTotal + next.PowerLevel / 2,
                d => d / 2);
            Console.WriteLine($"Aggregate 2 {aggregate2}");

            // Count
            // Heroes is a list, it has a Count property, use it if available
            var count = Heroes.Count;
            Console.WriteLine($"Heroes {count}");

            // this is enumerable, we don't know the count unless we call it
            // keep in mind that this is a O(n) operation
            count = Heroes.AsEnumerable().Count();
            Console.WriteLine($"Heroes Enumerable Count {count}");

            // use a predicate - no need for where!
            count = Heroes.Count(h => h.IsVillain);
            Console.WriteLine($"Villains {count}");

            // Max/Min - can only be used on numbers. 
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

        private static decimal SumFunction(Hero hero)
        {
            // we could have just put this in our sum function, but what if the logic if logic was more complicated
            return !hero.IsVillain ? hero.PowerLevel : decimal.Zero;
        } 
    }
}