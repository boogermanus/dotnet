using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class OrderingOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // OrderBy
            Console.WriteLine("Order by");
            var byPowerLevel = Heroes.OrderBy(h => h.PowerLevel);
            byPowerLevel.ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("Order by Descending");
            byPowerLevel = Heroes.OrderByDescending(h => h.PowerLevel);
            byPowerLevel.ToList().ForEach(Console.WriteLine);

            // not recommended
            Console.WriteLine("Order by then");
            var byNameAndPowerLevel = Heroes.OrderByDescending(h => h.PowerLevel)
                .ThenByDescending(h => h.Name);
            byNameAndPowerLevel.ToList().ForEach(Console.WriteLine);

            // meh
            Console.WriteLine("Reverse");
            var tempHeroes = new List<BaseCharacter>(Heroes);
            tempHeroes.ForEach(Console.WriteLine);
            tempHeroes.Reverse();
            tempHeroes.ForEach(Console.WriteLine);
        }
    }
}