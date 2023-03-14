using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class GenerationOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // Empty
            var empty = Enumerable.Empty<Hero>();
            Console.WriteLine($"{empty}");

            // Range
            var range = Enumerable.Range(0, 10);
            range.ToList().ForEach(Console.WriteLine);

            // Repeat - Neat! - you could randomly generate objets with a factory!
            var repeat = Enumerable.Repeat(new Hero(), 20);
            Console.WriteLine($"{repeat.Count()}");
        }
    }
}