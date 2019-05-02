using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{

    public class GroupByExamples
    {
        public static Guid groupId1 = Guid.NewGuid();
        public static Guid groupId2 = Guid.NewGuid();

        public List<Hero> heroes;

        public GroupByExamples()
        {
            heroes = new List<Hero>
            {
                new Hero(
                    "Batman", 
                    groupId1,
                    new List<Power>
                    {
                        new Power("None")
                    }
                ),
                new Hero(
                    "Hulk",
                    groupId2,
                    new List<Power>
                    {
                        new Power("Super Strength"),
                        new Power("Invulnerability"),
                        new Power("Smash")
                    }
                ),
                new Hero(
                    "Superman",
                    groupId1,
                    new List<Power>
                    {
                        new Power("Super Strength"),
                        new Power("Invulnerability"),
                        new Power("Heat Vision")
                    }
                ),
                new Hero(
                    "Captian America",
                    groupId2,
                    new List<Power>
                    {
                        new Power("Super Strength"),
                        new Power("Shield")
                    }
                ),
                new Hero(
                    "Wonder Women",
                    groupId1,
                    new List<Power>
                    {
                        new Power("Super Strength"),
                        new Power("Lasso of Truth")
                    }
                )
            };
        }

    }

    public class Hero
    {
        public Hero(string pName, Guid pGroupId, List<Power> pPowers)
        {
            name = pName;
            id = Guid.NewGuid();
            groupId = pGroupId;
            powers = pPowers;
            powers?.ForEach(p => p.heroId = id);
        }
        public string name { get; set; }
        public Guid id { get; set; }

        public Guid groupId { get; set; }

        public List<Power> powers { get; set; }
    }

    public class Power
    {
        public Power(string pPower) {
            name = pPower;
        }
        public string name { get; set; }
        public Guid heroId { get; set; }
    }

}