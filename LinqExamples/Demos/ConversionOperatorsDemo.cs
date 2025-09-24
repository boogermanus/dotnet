using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class ConversionOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // Cast
            Console.WriteLine("Cast - To Hero");
            var tempHeroes = new List<BaseCharacter>(Heroes);

            // only good when you're sure that everything is the same type of class
            var heroObjects = tempHeroes.Cast<Hero>().ToList();
            heroObjects.ForEach(Console.WriteLine);

            // OfType
            var mixedList = new List<BaseCharacter>(Heroes)
            {
                new Villain { Name = "Groud" },
                new Hero { Name = "Plastic Man" }
            };

            // neat! does this work with interfaces?
            var villains = mixedList.OfType<Villain>().ToList();
            Console.WriteLine(villains.Count);

            var interfaces = mixedList.OfType<IHero>().ToList();
            Console.WriteLine(interfaces.Count);

            // ToDictionary
            var heroDictionary = Heroes.ToDictionary(h => h.Name);
            Console.WriteLine($"Superman {heroDictionary["Superman"]}");
            heroDictionary.ToList().ForEach(k => Console.WriteLine($"{k.Key}"));

            // readability counts!
            var whereDictionary = Heroes.Where(h => h.PowerLevel > 80)
                .ToDictionary(h => h.Name);
            Console.WriteLine(whereDictionary.Count);

            try
            {
                var badDictionary = Heroes.ToDictionary(h => h.PowerLevel);
                Console.WriteLine(badDictionary.Keys.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}