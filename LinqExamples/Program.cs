using System;
using System.Collections.Generic;
using LinqExamples.Demos;
using LinqExamples.Interfaces;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var demos = new List<IDemo>
            {
                new AggregationDemo(),
                // new AggregationDemoWithInts(),
                // new ConversionOperatorsDemo(),
                // new ElementOperatorsDemo(),
                // new EqualityOperatorsDemo(),
                // new GenerationOperatorsDemo(),
                // new GroupingOperatorsDemo(),
                // new JoiningOperatorsDemo(),
                // new OrderingOperatorsDemo(),
                // new PartitioningOperatorsDemo(),
                // new RestrictionOperatorsDemo(),
                // new SelectionOperatorsDemo(),
                // new SetOperatorsDemo(),
                // new LetDemo(),
                // new VeryBadThingsDemo()
            };

            foreach (var demo in demos)
            {
                Console.WriteLine($"Running: {demo.GetType().Name}");
                demo.Run();
            }
        }
    }
}
