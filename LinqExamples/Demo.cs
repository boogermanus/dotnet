using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    public class Demo
    {
        private readonly List<Classification> _classifications = new()
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

        private readonly List<Hero> _heroes = new()
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
                Powers = Array.Empty<string>(),
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
                Powers = Array.Empty<string>(),
                IsVillain = true
            }
        };

        private readonly List<HeroSidekick> _sidekicks = new()
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
            var aggregate1 = _heroes.Aggregate(string.Empty,
                (longest, next) => next.Name.Length > longest.Length ? next.Name : longest, h => h.ToUpper());
            Console.WriteLine($"Aggregate 1: {aggregate1}");
            
            // Aggregate join
            var aggregateJoin = _heroes.Aggregate(",", (current, next) => $"{current},{next}");
            Console.WriteLine(aggregateJoin);

            // weird resharper thing here...
            var aggregate2 = _heroes.Aggregate(decimal.Zero, (halfTotal, next) => halfTotal + next.PowerLevel / 2,
                d => d);
            Console.WriteLine($"Aggregate 2 {aggregate2}");

            // Count
            var count = _heroes.Count; // Heroes is a list, it has a Count property, use it if available
            Console.WriteLine($"Heroes {count}");

            count = _heroes.AsEnumerable().Count(); // this is enumerable, we don't know the count unless we call it
            // keep in mind that this is a O(n) operation
            Console.WriteLine($"Heroes Enumerable Count {count}");

            // use a predicate - no need for where!
            count = _heroes.Count(h => h.IsVillain);
            Console.WriteLine($"Villains {count}");

            // Max/Min
            var max = _heroes.Max(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {max}");

            max = _heroes.Max(h => h.IsVillain ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {max}");

            var min = _heroes.Min(h => h.PowerLevel);
            Console.WriteLine($"Max PowerLevel {min}");

            min = _heroes.Min(h => h.PowerLevel > 80 ? h.PowerLevel : decimal.Zero);
            Console.WriteLine($"Max Villain PowerLevel {min}");

            // Sum
            var sum = _heroes.Sum(h => h.PowerLevel);
            Console.WriteLine($"PowerLevel Sum {sum}");

            // a method group, the variable is assumed
            sum = _heroes.Sum(SumFunction);

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
            var tempHeroes = new List<IHero>(_heroes);

            // only good where your sure that everything is the same type of interface
            var heroObjects = tempHeroes.Cast<Hero>().ToList();
            heroObjects.ForEach(Console.WriteLine);

            // OfType
            var mixedList = new List<IHero>(_heroes)
            {
                new Villain {Name = "Captain Cold", Hero = "Flash"},
                new Villain {Name = "Doomsday", Hero = "Superman"}
            };

            // neat! does this work with interfaces?
            var villains = mixedList.OfType<Villain>().ToList();
            Console.WriteLine(villains.Count);

            // ToDictionary
            var heroDictionary = _heroes.ToDictionary(h => h.Name);
            Console.WriteLine($"Superman {heroDictionary["Superman"]}");
            heroDictionary.ToList().ForEach(k => Console.WriteLine($"{k.Key}"));

            // readability counts!
            var whereDictionary = _heroes.Where(h => h.PowerLevel > 80)
                .ToDictionary(h => h.Name);
            Console.WriteLine(whereDictionary.Count);

            try
            {
                var badDictionary = _heroes.ToDictionary(h => h.PowerLevel);
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
            var defaultIfEmpty = new List<Hero>().DefaultIfEmpty().ToList();
            
            // if we add ToArray here suddenly rider doesn't care about multiple enumerations
            // var defaultIfEmpty = new List<Hero>().DefaultIfEmpty().ToArray();
            Console.WriteLine($"{defaultIfEmpty.Count()}");
            Console.WriteLine($"{defaultIfEmpty.ElementAt(0)}");

            // ElementAt
            var element = _heroes.ElementAt(0);
            Console.WriteLine($"{element}");

            // First
            var first = _heroes.First();
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
            var firstOrDefault = _heroes.FirstOrDefault();
            Console.WriteLine($"{firstOrDefault}");

            firstOrDefault = new List<Hero>().FirstOrDefault();
            Console.WriteLine($"{firstOrDefault}");

            // Single - dont ever use this
            var single = _heroes.Single(h => h.Name == "Superman");
            Console.WriteLine($"{single}");

            try
            {
                // if you use single or default, you're a bad person.
                var singleOrDefault = _heroes.SingleOrDefault(h => h.PowerLevel == 99.9m);
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
            var otherHeroes = new List<Hero>(_heroes);
            var assert = _heroes.SequenceEqual(otherHeroes);
            Console.WriteLine($"{assert}");

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

            var superman2 = new Hero
            {
                Name = "Superman"
            };

            var list1 = new List<Hero> {superman};

            var list2 = new List<Hero> {superman2};

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
            var byTeam = _heroes.GroupBy(h => h.Team);
            foreach (var team in byTeam)
            {
                Console.WriteLine(team.Key);
                team.Select(t => t.Name).ToList().ForEach(Console.WriteLine);
            }
        }

        public void JoiningOperators()
        {
            
            // don't know when you'd ever use this...
            var groupJoin = _classifications.GroupJoin(_sidekicks, std => std.Id, s => s.ClassificationId,
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

            // join is the bomb
            var heroes = _heroes.Join(_sidekicks, h => h.Name, hs => hs.Partner, (h, hs) => h);
            heroes.ToList().ForEach(Console.WriteLine);
            
            // discard the parameter
            var moreHeroes = _heroes.Join(_sidekicks, h => h.Name, hs => hs.Partner, (h, _) => h);
            moreHeroes.ToList().ForEach(Console.WriteLine);

            // still being the bomb
            var teams = _heroes.Join(_sidekicks, h => h.Name, hs => hs.Partner, (h, hs) => new
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
            // OrderBy
            var byPowerLevel = _heroes.OrderBy(h => h.PowerLevel);
            byPowerLevel.
                ToList()
                .ForEach(Console.WriteLine);

            byPowerLevel = _heroes.OrderByDescending(h => h.PowerLevel);
            byPowerLevel.ToList().ForEach(Console.WriteLine);

            // not recommended
            var byNameAndPowerLevel = _heroes.OrderByDescending(h => h.PowerLevel)
                .ThenByDescending(h => h.Name);
            byNameAndPowerLevel.ToList().ForEach(Console.WriteLine);

            // meh
            var tempHeroes = new List<Hero>(_heroes);
            tempHeroes.ForEach(Console.WriteLine);
            tempHeroes.Reverse();
            tempHeroes.ForEach(Console.WriteLine);
        }

        public void PartitioningOperators()
        {
            // Skip
            _heroes.Skip(2)
                .ToList()
                .ForEach(Console.WriteLine);
            _heroes.SkipLast(2)
                .ToList()
                .ForEach(Console.WriteLine);
            _heroes.SkipWhile(h => h.PowerLevel > 80)
                .ToList()
                .ForEach(Console.WriteLine);

            // Take
            _heroes
                .Take(2)
                .ToList()
                .ForEach(Console.WriteLine);
            _heroes.TakeLast(2)
                .ToList()
                .ForEach(Console.WriteLine);
            _heroes.TakeWhile(h => h.PowerLevel > 80).ToList().ForEach(Console.WriteLine);
        }

        public void QuantifierOperators()
        {
            // All
            var havePowerLevelGreaterThan20 = _heroes.All(h => h.PowerLevel > 20);
            Console.WriteLine(havePowerLevelGreaterThan20);
            
            // Any
            var havePowerLevel80 = _heroes.Any(h => h.PowerLevel == 80);
            Console.WriteLine(havePowerLevel80);

            // seems to work with out IEquatable
            var superman = _heroes[0];
            var contains = _heroes.Contains(superman);
            Console.WriteLine(contains);

            // smash
            var hulk = new Hero()
            {
                Name = "Hulk",
            };

            // it works, but I still wonder what the default 'deep' equal is
            contains = _heroes.Contains(hulk);
            Console.WriteLine(contains);
        }

        public void RestrictionOperators()
        {
            // basic Where
            var wherePowerLevelGreaterThan80 = _heroes.Where(h => h.PowerLevel > 80);
            wherePowerLevelGreaterThan80
                .ToList()
                .ForEach(Console.WriteLine);

            // for jesse
            var superman = _heroes.Where(h => h.Name.ToLower() == "superman"
                                              && h.PowerLevel == 99.9m && h.Team.ToUpper() == "JLA"
                                              && h.Powers.Contains("flight"));
            Console.WriteLine(superman);

            // prettier
            superman = _heroes.Where(h => h.Name.ToLower() == "superman")
                .Where(h => h.PowerLevel == 99.9m)
                .Where(h => h.Team.ToUpper() == "JLA")
                .Where(h => h.Powers.Contains("flight"));
            Console.WriteLine(superman);

            // preferred 
            superman = _heroes.Where(IsSuperman);
            Console.WriteLine(superman);

            // clean code
            superman = _heroes.Where(IsSupermanCleanCode);
            Console.WriteLine(superman);

            // be careful when using multiple wheres!
            var notSupermanAndWonderWomen = _heroes.Where(h => h.Powers.Contains("heat vision"))
                .Where(h => h.Powers.Contains("lasso of truth"));
            Console.WriteLine(notSupermanAndWonderWomen.Count());

            // drake right
            var supermanAndWonderWomen =
                _heroes.Where(h => h.Powers.Contains("heat vision") || h.Powers.Contains("lasso of truth")).ToList();
            Console.WriteLine(supermanAndWonderWomen);
            
            // drake right clean
            var enumerable = supermanAndWonderWomen.Where(h => HasHeatVisionOrLassoOfTruth(h.Powers));
            Console.WriteLine(enumerable.Count());

        }

        private static bool IsSuperman(Hero hero)
        {
            return hero.Name.ToLower().Equals("superman") && hero.PowerLevel.Equals(99.9m) &&
                   hero.Team.ToUpper().Equals("JLA") && hero.Powers.Contains("flight");
        }

        private static bool IsSupermanCleanCode(Hero hero)
        {
            return NameIsSuperman(hero.Name) && PowerLevelIsMax(hero.PowerLevel) && IsJlaMember(hero.Team) &&
                   HasFlightPower(hero.Powers);
        }

        private static bool NameIsSuperman(string name)
        {
            return name.ToLower().Equals("superman");
        }

        private static bool PowerLevelIsMax(decimal powerLevel)
        {
            return powerLevel.Equals(99.9m);
        }

        private static bool IsJlaMember(string team)
        {
            return team.ToLower().Equals("jla");
        }

        private static bool HasFlightPower(IEnumerable<string> powers)
        {
            return powers.Contains("flight");
        }

        private static bool HasHeatVisionOrLassoOfTruth(IEnumerable<string> powers)
        {
            var enumerable = powers as string[] ?? powers.ToArray();
            return enumerable.Contains("heat vision") || enumerable.Contains("lasso of truth");
        }

        public void SelectionOperators()
        {
            // basic Select
            _heroes.Select(h => h.PowerLevel)
                .ToList()
                .ForEach(Console.WriteLine);

            // new objects!
            var newObjects = _heroes.Select(h => new {h.Name, h.PowerLevel})
                .ToList();

            // we can't use foreach on the object
            foreach (var newObject in newObjects)
            {
                Console.WriteLine($"{newObject.Name} - {newObject.PowerLevel}");
            }

            // professional level
            _heroes.Select(h => new Hero
                {
                    Name = h.Name
                })
                .ToList()
                .ForEach(Console.WriteLine);
                

            // with where
            _heroes
                .Where(h => PowerLevelIsMax(h.PowerLevel))
                .Select(h => h.Name)
                .ToList()
                .ForEach(Console.WriteLine);

            // flatten
            _heroes.SelectMany(h => h.Powers)
                .ToList()
                .ForEach(Console.WriteLine);

            // good use of where
            _heroes.Where(h => PowerLevelIsMax(h.PowerLevel))
                .SelectMany(h => h.Powers)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void SetOperators()
        {
            var newHeroes = new List<Hero>
            {
                new()
                {
                    Name = "Green Lantern",
                    PowerLevel = 67.22m,
                    Powers = new[] {"ring"},
                    Team = "JLA"
                },
                new()
                {
                    Name = "Plastic Man",
                    PowerLevel = 92.1m,
                    Powers = new[] {"shape", "invulnerable"},
                    Team = "JLA"
                }
            };

            // Concat
            var newJla = _heroes.Concat(newHeroes)
                .ToList();
            Console.WriteLine(newJla.Count);

            // Distinct
            newJla.SelectMany(h => h.Powers)
                .Distinct()
                .ToList()
                .ForEach(Console.WriteLine);

            var batmanAndSuperMan = new List<Hero>
            {
                new()
                {
                    Name = "Batman",
                    PowerLevel = 99.9m
                },
                new()
                {
                    Name = "Superman",
                    PowerLevel = 99.9m
                }
            };
            
            // Except
            var except = _heroes.Except(batmanAndSuperMan);
            except.ToList()
                .ForEach(Console.WriteLine);

            // Intersect
            var intersect = _heroes.Intersect(batmanAndSuperMan);
            
            intersect.ToList()
                .ForEach(Console.WriteLine);

            // Union - lame
            var union = _heroes.Union(batmanAndSuperMan);
            
            union.ToList()
                .ForEach(Console.WriteLine);

            // linq master!
            var allPowerLevels = _heroes.Union(newHeroes)
                .Union(batmanAndSuperMan)
                .Select(h => h.PowerLevel)
                .OrderByDescending(h => h)
                .Distinct();
            
            allPowerLevels.ToList()
                .ForEach(Console.WriteLine);
        }

        public void UsingLet()
        {
            // find everyone who's first power isn't flight
            var stuff = _heroes.Select(h => new { hero = h, firstPower = h.Powers.FirstOrDefault() })
                .Where(h => h.firstPower != "flight")
                .Select(h => h.hero);
            stuff.ToList().ForEach(Console.WriteLine);
        }

        public void VeryBadThings()
        {
            // dont use select, use where
            var dumbQuery = _heroes.Select(h => h.PowerLevel > 80);
            Console.WriteLine($"{dumbQuery.Count()}"); // is equal to six, not 4!

            // using pretty much anything after a where
            var wasteful = _heroes.Where(h => h.PowerLevel > 80).FirstOrDefault();
            var notWasteFul = _heroes.FirstOrDefault(h => h.PowerLevel > 80);
            
            var notWithAny = _heroes.Where(h => h.PowerLevel > 20).Any();

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