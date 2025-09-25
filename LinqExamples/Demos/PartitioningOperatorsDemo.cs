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
            
            //skip first two
            Heroes.Skip(2)
                .ToList()
                .ForEach(Console.WriteLine);
            
            // skip last two
            Heroes.SkipLast(2)
                .ToList()
                .ForEach(Console.WriteLine);
            
            // skip heroes with a power level greater than 80
            Heroes.SkipWhile(h => h.PowerLevel > 80)
                .ToList()
                .ForEach(Console.WriteLine);

            // Take
            
            // take first two
            Heroes
                .Take(2)
                .ToList()
                .ForEach(Console.WriteLine);
            
            // take last two
            Heroes.TakeLast(2)
                .ToList()
                .ForEach(Console.WriteLine);
            
            // take while some condition 
            Heroes.TakeWhile(h => h.PowerLevel > 80).ToList().ForEach(Console.WriteLine);
        }
    }
}