using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class SetOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            var newHeroes = new List<Hero>
            {
                new()
                {
                    Name = "Green Lantern",
                    PowerLevel = 67.22m,
                    Powers = new[] { "ring" },
                    Team = "JLA"
                },
                new()
                {
                    Name = "Plastic Man",
                    PowerLevel = 92.1m,
                    Powers = new[] { "shape", "invulnerable" },
                    Team = "JLA"
                }
            };

            // Concat
            var newJla = Heroes.Concat(newHeroes)
                .ToList();
            Console.WriteLine(newJla.Count);

            // Distinct
            newJla.SelectMany(h => h.Powers)
                .Distinct()
                .ToList()
                .ForEach(Console.WriteLine);

            var batmanAndSuperMan = new List<Hero>
            {
                new()
                {
                    Name = "Batman",
                    PowerLevel = 99.9m
                },
                new()
                {
                    Name = "Superman",
                    PowerLevel = 99.9m
                }
            };

            // Except
            var except = Heroes.Except(batmanAndSuperMan);
            except.ToList()
                .ForEach(Console.WriteLine);

            // Intersect
            var intersect = Heroes.Intersect(batmanAndSuperMan);

            intersect.ToList()
                .ForEach(Console.WriteLine);

            // Union - lame
            var union = Heroes.Union(batmanAndSuperMan);

            union.ToList()
                .ForEach(Console.WriteLine);

            // linq master!
            var allPowerLevels = Heroes.Union(newHeroes)
                .Union(batmanAndSuperMan)
                .Select(h => h.PowerLevel)
                .OrderByDescending(h => h)
                .Distinct();

            allPowerLevels.ToList()
                .ForEach(Console.WriteLine);
        }
    }
}