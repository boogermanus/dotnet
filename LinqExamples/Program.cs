using System;
using System.Collections.Generic;
using LinqExamples.Demos;
using LinqExamples.Interfaces;
using LinqExamples.Models;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // var demo = new Demo();
            //
            // demo.AggregationOperators();
            // demo.ConversionOperators();
            // demo.ElementOperators();
            // demo.EqualityOperators();
            // demo.GenerationOperators();
            // demo.GroupingOperators();
            // demo.JoiningOperators();
            // demo.OrderingOperators();
            // demo.PartitioningOperators();
            // demo.QuantifierOperators();
            // demo.RestrictionOperators();
            // demo.SelectionOperators();
            // demo.SetOperators();
            // demo.UsingLet();
            // demo.VeryBadThings();

            var demos = new List<IDemo> { new AggregationDemo(), new AggregationDemoWithInts() };

            foreach (var demo in demos)
            {
                demo.Run();
            }
        }
    }
}
