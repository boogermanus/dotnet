using System;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class GenerationOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // Empty
            Console.WriteLine("Empty");
            var empty = Enumerable.Empty<Hero>();
            Console.WriteLine($"{empty}");

            // Range
            Console.WriteLine("Range");
            var range = Enumerable.Range(0, 10);
            range.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Repeat");
            // Repeat - Neat! - you could randomly generate objets with a factory!
            var repeat = Enumerable.Repeat(new Hero(), 20);
            Console.WriteLine($"{repeat.Count()}");
        }
    }
}