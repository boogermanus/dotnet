using System;
using System.Collections.Generic;
using LinqExamples.Interfaces;

namespace LinqExamples.Models
{
    public abstract class DemoBase : IDemo
    {
        protected readonly List<Classification> Classifications = new()
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
        
        protected readonly List<BaseCharacter> Heroes = new()
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
            new Villain
            {
                Name = "Lex Luthor",
                PowerLevel = 80,
                Powers = new[] {"intelligence"},
                IsVillain = true,
                Team = "Injustice League"
            },
            new Villain
            {
                Name = "The Joker",
                PowerLevel = 71.2m,
                Powers = Array.Empty<string>(),
                IsVillain = true,
                Team = "None"
            }
        };
        
        protected readonly List<HeroSidekick> Sidekicks = new()
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

        public abstract void Run();
    }
}