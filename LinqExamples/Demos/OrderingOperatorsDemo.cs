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
            var byPowerLevel = Heroes.OrderBy(h => h.PowerLevel);
            byPowerLevel.ToList()
                .ForEach(Console.WriteLine);

            byPowerLevel = Heroes.OrderByDescending(h => h.PowerLevel);
            byPowerLevel.ToList().ForEach(Console.WriteLine);

            // not recommended
            var byNameAndPowerLevel = Heroes.OrderByDescending(h => h.PowerLevel)
                .ThenByDescending(h => h.Name);
            byNameAndPowerLevel.ToList().ForEach(Console.WriteLine);

            // meh
            var tempHeroes = new List<BaseCharacter>(Heroes);
            tempHeroes.ForEach(Console.WriteLine);
            tempHeroes.Reverse();
            tempHeroes.ForEach(Console.WriteLine);
        }
    }
}