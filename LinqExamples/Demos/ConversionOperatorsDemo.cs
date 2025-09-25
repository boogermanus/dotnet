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
            Console.WriteLine("Cast - To IHero");
            var tempHeroes = new List<BaseCharacter>(Heroes);

            // only good when you're sure that everything is the same type of class
            var heroObjects = tempHeroes.Cast<IHero>().ToList();
            heroObjects.ForEach(Console.WriteLine);

            // this will fail, you cannot cast Villains 
            Console.WriteLine("Cast - To Hero");
            try
            { 
                tempHeroes.Cast<Hero>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("OfType");
            // OfType
            var mixedList = new List<BaseCharacter>(Heroes)
            {
                new Villain { Name = "Groud" },
                new Hero { Name = "Plastic Man" }
            };

            // neat!
            var villains = mixedList.OfType<Villain>().ToList();
            Console.WriteLine($"There are {villains.Count} villains");

            // does this work with interfaces?
            var interfaces = mixedList.OfType<IHero>().ToList();
            Console.WriteLine($"There are {interfaces.Count} IHero interfaces");

            // ToDictionary
            Console.WriteLine("ToDictionary");
      
            var heroDictionary = Heroes.ToDictionary(h => h.Name);
            Console.WriteLine($"Superman {heroDictionary["Superman"]}");
            heroDictionary.ToList().ForEach(k => Console.WriteLine($"{k.Key}"));

            // readability counts!
            var whereDictionary = Heroes.Where(h => h.PowerLevel > 80)
                .ToDictionary(h => h.Name);
            Console.WriteLine($"There are {whereDictionary.Count} characters with power level > 80");

            Console.WriteLine("BadDictionary");
            // does not work because power level can be the same
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