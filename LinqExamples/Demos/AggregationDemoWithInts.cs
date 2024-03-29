﻿using System.Collections.Generic;
using System.Linq;
using LinqExamples.Models;

namespace LinqExamples.Demos
{
    internal class HeroInt
    {
        public HeroInt(string name, int power)
        {
            Name = name;
            Power = power;
        }
        public string Name;
        public int Power;
    }
    
    public class AggregationDemoWithInts :  DemoBase
    {
        public override void Run()
        {
            var heroInts = new List<HeroInt>
            {
                new HeroInt("flash", 1),
                new HeroInt("superman", 1),
                new HeroInt("batman", 0),
                new HeroInt("joker", 0)
            };

            var max = heroInts.Max(h => h.Power);
        }
    }
}