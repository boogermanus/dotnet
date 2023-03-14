using System;
using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    public class RestrictionOperatorsDemo : DemoBase
    {
        public override void Run()
        {
            // basic Where
            var wherePowerLevelGreaterThan80 = Heroes.Where(h => h.PowerLevel > 80);
            wherePowerLevelGreaterThan80
                .ToList()
                .ForEach(Console.WriteLine);

            // for jesse
            var superman = Heroes.Where(h => h.Name.ToLower() == "superman"
                                              && h.PowerLevel == 99.9m && h.Team.ToUpper() == "JLA"
                                              && h.Powers.Contains("flight"));
            Console.WriteLine(superman);

            // prettier
            superman = Heroes.Where(h => h.Name.ToLower() == "superman")
                .Where(h => h.PowerLevel == 99.9m)
                .Where(h => h.Team.ToUpper() == "JLA")
                .Where(h => h.Powers.Contains("flight"));
            Console.WriteLine(superman);

            // preferred 
            superman = Heroes.Where(IsSuperman);
            Console.WriteLine(superman);

            // clean code
            superman = Heroes.Where(IsSupermanCleanCode);
            Console.WriteLine(superman);

            // be careful when using multiple wheres!
            var notSupermanAndWonderWomen = Heroes.Where(h => h.Powers.Contains("heat vision"))
                .Where(h => h.Powers.Contains("lasso of truth"));
            Console.WriteLine(notSupermanAndWonderWomen.Count());

            // drake right
            var supermanAndWonderWomen =
                Heroes.Where(h => h.Powers.Contains("heat vision") || h.Powers.Contains("lasso of truth")).ToList();
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
    }
}