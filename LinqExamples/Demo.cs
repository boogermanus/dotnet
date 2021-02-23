using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    public class Demo
    {
        private List<Classification> Classifications = new()
        {
            new Classification
            {
                Id = 1,
                ClassificationName = "Excellent"
            },
            new Classification
            {
                Id = 2,
                ClassificationName = "Good"
            }
        };
        private List<Hero> Heroes = new()
        {
            new Hero
            {
                Name = "Superman",
                PowerLevel = 99.9m,
                Powers = new[] {"flight", "heat vision", "strength"},
                Team = "JLA"
            },
            new Hero
            {
                Name = "Batman",
                PowerLevel = 99.9m,
                Powers = new string[0],
                Team = "JLA"
            },
            new Hero
            {
                Name = "Wonder Women",
                PowerLevel = 89,
                Powers = new[] {"flight", "strength", "lasso of truth"},
                Team = "JLA"
            },
            new Hero
            {
                Name = "Flash",
                PowerLevel = 78.2m,
                Powers = new[] {"speed", "time travel"},
                Team = "JLA"
            },
            new Hero
            {
                Name = "Lex Luthor",
                PowerLevel = 80,
                Powers = new[] {"intelligence"},
                IsVillain = true,
                Team = "Injustice League"
            },
            new Hero
            {
                Name = "The Joker",
                PowerLevel = 71.2m,
                Powers = new string[0],
                IsVillain = true
            }
        };

        private List<HeroSidekick> Sidekicks = new()
        {
            new HeroSidekick
            {
                Name = "Robin",
                Partner = "Batman",
                ClassificationId = 1
            },
            new HeroSidekick
            {
                Name = "Kid Flash",
                Partner = "Flash",
                ClassificationId = 2
            },
            new HeroSidekick
            {
                Name = "Harley Quinn",
                Partner = "The Joker"
            }
        };
        
        public void AggregationOperators()
        {
            // Aggregate
            var aggregate1 = Heroes.Aggregate(string.Empty, 
                (longest, next) => next.Name.Length > longest.Length ? next.Name : longest, h => h.ToUpper());
            Console.WriteLine($"Aggregate 1: {aggregate1}");

            // weird resharper thing here...
            var aggregate2 = Heroes.Aggregate(decimal.Zero, (halfTotal, next) => halfTotal += next.PowerLevel/2, d => d);
            Console.WriteLine($"Aggregate 2 {aggregate2}");

            // Count
            var count = Heroes.Count; // Heroes is a list, it has a Count property, use it if available
            Console.WriteLine($"Heroes {count}");

            count = Heroes.AsEnumerable().Count(); // this is enumerable, we don't know the count unless we call it
            // keep in mind that this is a O(n) operation
            Console.WriteLine($"Heroes Enumerable Count {count}");

            // use a predicate - no need for where!
            count = Heroes.Count(h => h.IsVillain);
            Console.WriteLine($"Villains {count}");

            // Max/Min
            var max = Heroes.Max(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {max}");

            max = Heroes.Max(h => h.IsVillain ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {max}");

            var min = Heroes.Min(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {min}");

            min = Heroes.Min(h => h.PowerLevel > 80 ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {min}");

            // Sum
            var sum = Heroes.Sum(h => h.PowerLevel);
            Console.WriteLine($"PowerLevel Sum {sum}");

            // a method group, the variable is assumed
            sum = Heroes.Sum(SumFunction);

            Console.WriteLine($"Heroes PowerLevel {sum}");
        }

        private static decimal SumFunction(Hero hero)
        {
            // we could have just put this in our sum function, but what if the logic if logic was more complicated
            return !hero.IsVillain ? hero.PowerLevel : decimal.Zero;
        }

        public void ConversionOperators()
        {
            // Cast
            var tempHeroes = new List<IHero>(Heroes);
            
            //only good where your sure that everything is the same type of interface
            var heroObjects = tempHeroes.Cast<Hero>().ToList();
            heroObjects.ForEach(Console.WriteLine);

            // OfType
            List<IHero> mixedList = new List<IHero>(Heroes);
            mixedList.Add(new Villain
            {
                Name = "Captain Cold",
                Hero = "Flash"
            });
            mixedList.Add(new Villain
            {
                Name = "Doomsday",
                Hero = "Superman"
            });

            // neat! does this work with interfaces?
            var villains = mixedList.OfType<Villain>().ToList();
            Console.WriteLine(villains.Count);

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

        public void ElementOperators()
        {
            // DefaultIfEmpty
            // never used this. bit it seems a good way to fake things...
            var defaultIfEmpty = new List<Hero>().DefaultIfEmpty();
            
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

        public void EqualityOperators()
        {
            // deep check
            var otherHeroes = new List<Hero>(Heroes);
            var assert = Heroes.SequenceEqual(otherHeroes);
            Console.WriteLine($"{assert}");

            // not the same list
            var superman = new Hero
            {
                Name = "Superman"
            };

            var real = new List<Hero>();
            real.Add(superman);

            var bizarro = new Hero
            {
                Name = "bizarro"
            };

            var fake = new List<Hero>();
            fake.Add(bizarro);
            
            assert = real.SequenceEqual(fake);
            Console.WriteLine($"{assert}");

            var superman2 = new Hero
            {
                Name = "Superman"
            };

            var list1 = new List<Hero>();
            list1.Add(superman);

            var list2 = new List<Hero>();
            list2.Add(superman2);

            assert = list1.SequenceEqual(list2);
            Console.WriteLine($"{assert}");
        }
        
        public void GenerationOperators()
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

        public void GroupingOperators()
        {
            var byTeam = Heroes.GroupBy(h => h.Team);
            foreach (var team in byTeam)
            {
                Console.WriteLine(team.Key);
                team.Select(t => t.Name).ToList().ForEach(Console.WriteLine);
            }
        }

        public void JoiningOperators()
        {
            var groupJoin = Classifications.GroupJoin(Sidekicks, std => std.Id, s => s.ClassificationId,
                (std, sidekickGroup) => new
                {
                    Sidekicks = sidekickGroup,
                    Name = std.ClassificationName
                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.Name);
                item.Sidekicks.ToList().ForEach(Console.WriteLine);
            }

            var heroes = Heroes.Join(Sidekicks, h => h.Name, hs => hs.Partner, (h, hs) => h);
            heroes.ToList().ForEach(Console.WriteLine);

            var teams = Heroes.Join(Sidekicks, h => h.Name, hs => hs.Partner, (h, hs) => new
            {
                Hero = h.Name,
                Sidekick = hs.Name
            }).ToList();

            foreach (var team in teams)
            {
                Console.WriteLine($"Team - {team.Hero}/{team.Sidekick}");
            }
        }

        public void OrderingOperators()
        {
            var byPowerLevel = Heroes.OrderBy(h => h.PowerLevel);
            byPowerLevel.ToList().ForEach(Console.WriteLine);

            byPowerLevel = Heroes.OrderByDescending(h => h.PowerLevel);
            byPowerLevel.ToList().ForEach(Console.WriteLine);

            // not recommended
            var byNameAndPowerLevel = Heroes.OrderByDescending(h => h.PowerLevel)
                .ThenByDescending(h => h.Name);
            byNameAndPowerLevel.ToList().ForEach(Console.WriteLine);

            var tempHeroes = new List<Hero>(Heroes);
            tempHeroes.ForEach(Console.WriteLine);
            tempHeroes.Reverse();
            tempHeroes.ForEach(Console.WriteLine);
        }

        public void VeryBadThings()
        {
            // dont use select, use where
            var dumbQuery = Heroes.Select(h => h.PowerLevel > 80);
            Console.WriteLine($"{dumbQuery.Count()}"); // is equal to six, not 4!
            
            // trust rider
            var wasteful = Heroes.Where(h => h.PowerLevel > 80).FirstOrDefault();
            var notWasteFul = Heroes.FirstOrDefault(h => h.PowerLevel > 80);

        }
    }


}