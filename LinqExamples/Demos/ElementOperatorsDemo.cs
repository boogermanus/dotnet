using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class ElementOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // DefaultIfEmpty
            // never used this. bit it seems a good way to fake things...
            var defaultIfEmpty = new List<Hero>().DefaultIfEmpty().ToList();

            // if we add ToArray here suddenly rider doesn't care about multiple enumerations
            // var defaultIfEmpty = new List<Hero>().DefaultIfEmpty().ToArray();
            Console.WriteLine($"{defaultIfEmpty.Count()}");
            Console.WriteLine($"{defaultIfEmpty.ElementAt(0)}");

            // ElementAt
            var element = Heroes.ElementAt(0);
            Console.WriteLine($"{element}");

            // First
            var first = Heroes.First();
            Console.WriteLine($"{first}");

            try
            {
                var list = new List<Hero>();
                var badFirst = list.First();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // FirstOrDefault
            var firstOrDefault = Heroes.FirstOrDefault();
            Console.WriteLine($"{firstOrDefault}");

            firstOrDefault = new List<Hero>().FirstOrDefault();
            Console.WriteLine($"{firstOrDefault}");

            // Single - dont ever use this
            var single = Heroes.Single(h => h.Name == "Superman");
            Console.WriteLine($"{single}");

            try
            {
                // if you use single or default, you're a bad person.
                var singleOrDefault = Heroes.SingleOrDefault(h => h.PowerLevel == 99.9m);
                Console.WriteLine($"{singleOrDefault}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}