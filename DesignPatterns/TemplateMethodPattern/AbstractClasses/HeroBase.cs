using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateMethodPattern.AbstractClasses
{
    public abstract class HeroBase
    {
        protected abstract string Name {get;}
        protected abstract string City {get;}
        protected List<string> _powers = new List<string>();
        private IEnumerable<string> Powers => _powers;

        public abstract void MakeHero();

        public virtual void Introduce()
        {
            Console.WriteLine($"I am {Name} and I serve {City}");

            if(_powers.Any())
            {
                Console.WriteLine($"My Powers are:");
                foreach(var power in Powers)
                {
                    Console.WriteLine($"{power}");
                }
            }
        }
    }
}