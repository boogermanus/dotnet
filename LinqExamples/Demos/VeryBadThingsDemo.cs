using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class VeryBadThingsDemo : DemoBase
    {
        public override void Run()
        {
            // dont use select, use where
            var dumbQuery = Heroes.Select(h => h.PowerLevel > 80);
            Console.WriteLine($"{dumbQuery.Count()}"); // is equal to six, not 4!

            // using pretty much anything after a where
            var wasteful = Heroes.Where(h => h.PowerLevel > 80).FirstOrDefault();
            var notWasteFul = Heroes.FirstOrDefault(h => h.PowerLevel > 80);

            var notWithAny = Heroes.Where(h => h.PowerLevel > 20).Any();

            // watch out for casting issues!
            var mixed = new List<IHero>
            {
                new Hero()
                {
                    Name = "Martian Manhunter"
                },
                new Villain()
                {
                    Name = "Darkseid"
                }
            };

            var badCast = mixed.Cast<Hero>();

            try
            {
                var badList = badCast.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}