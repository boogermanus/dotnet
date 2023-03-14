using System;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class LetDemo : DemoBase
    {
        public override void Run()
        {
            // don't use query syntax
            var badStuff = from h in Heroes
                let firstPower = h.Powers.FirstOrDefault()
                where firstPower != "flight"
                select h;

            badStuff.ToList().ForEach(Console.WriteLine);

            // find everyone who's first power isn't flight
            var stuff = Heroes.Select(hero => new { hero, firstPower = hero.Powers.FirstOrDefault() })
                .Where(h => h.firstPower != "flight")
                .Select(h => h.hero);
            stuff.ToList().ForEach(Console.WriteLine);
        }
    }
}