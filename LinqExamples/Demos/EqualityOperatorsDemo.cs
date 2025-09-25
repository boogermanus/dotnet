using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class EqualityOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // deep check
            Console.WriteLine("DeepCheck");
            var otherHeroes = new List<BaseCharacter>(Heroes);
            var assert = Heroes.SequenceEqual(otherHeroes);
            Console.WriteLine($"{assert}");

            Console.WriteLine("Not the same list");
            // not the same list
            var superman = new Hero
            {
                Name = "Superman"
            };

            var real = new List<Hero> {superman};

            var bizarro = new Hero
            {
                Name = "Bizarro"
            };

            var fake = new List<Hero> {bizarro};

            assert = real.SequenceEqual(fake);
            Console.WriteLine($"{assert}");

            Console.WriteLine("Superman equal to Superman?");
            var superman2 = new Hero
            {
                Name = "Superman"
            };

            var list1 = new List<Hero> {superman};

            var list2 = new List<Hero> {superman2};

            assert = list1.SequenceEqual(list2);
            Console.WriteLine($"{assert}");
        }
    }
}