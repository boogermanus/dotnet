using System;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class SelectionOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // basic Select
            Heroes.Select(h => h.PowerLevel)
                .ToList()
                .ForEach(Console.WriteLine);

            // new objects!
            var newObjects = Heroes.Select(h => new { h.Name, h.PowerLevel })
                .ToList();

            // we can't use foreach on the object
            foreach (var newObject in newObjects)
            {
                Console.WriteLine($"{newObject.Name} - {newObject.PowerLevel}");
            }

            // professional level
            Heroes.Select(h => new Hero
                {
                    Name = h.Name
                })
                .ToList()
                .ForEach(Console.WriteLine);


            // with where
            Heroes
                .Where(h => PowerLevelIsMax(h.PowerLevel))
                .Select(h => h.Name)
                .ToList()
                .ForEach(Console.WriteLine);

            // flatten
            Heroes.SelectMany(h => h.Powers)
                .ToList()
                .ForEach(Console.WriteLine);

            // good use of where
            Heroes.Where(h => PowerLevelIsMax(h.PowerLevel))
                .SelectMany(h => h.Powers)
                .ToList()
                .ForEach(Console.WriteLine);
        }
        
        private static bool PowerLevelIsMax(decimal powerLevel)
        {
            return powerLevel.Equals(99.9m);
        }
    }
}