using System;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class PartitioningOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // Skip
            Heroes.Skip(2)
                .ToList()
                .ForEach(Console.WriteLine);
            Heroes.SkipLast(2)
                .ToList()
                .ForEach(Console.WriteLine);
            Heroes.SkipWhile(h => h.PowerLevel > 80)
                .ToList()
                .ForEach(Console.WriteLine);

            // Take
            Heroes
                .Take(2)
                .ToList()
                .ForEach(Console.WriteLine);
            Heroes.TakeLast(2)
                .ToList()
                .ForEach(Console.WriteLine);
            Heroes.TakeWhile(h => h.PowerLevel > 80).ToList().ForEach(Console.WriteLine);
        }
    }
}