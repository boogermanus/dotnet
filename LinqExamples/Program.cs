using System;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();

            demo.AggregationOperators();
            demo.ConversionOperators();
            demo.ElementOperators();
            demo.EqualityOperators();
            demo.GenerationOperators();
            demo.GroupingOperators();
            demo.JoiningOperators();
            demo.OrderingOperators();
            demo.PartitioningOperators();
            demo.QuantifierOperators();
            demo.VeryBadThings();
        }
    }
}
