using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteCreator
{
    public abstract class Hero
    {
        public abstract string Name { get; }

        protected List<PowerBase> _powers = new List<PowerBase>();
        public List<PowerBase> Powers => _powers;

        public Hero()
        {
            MakeHero();
        }

        public abstract void MakeHero();

        public override string ToString()
        {
            var powers = Powers.Select(p => p.Power);

            return new StringBuilder()
                .AppendLine($"I'm {Name}, and my powers are:")
                .AppendLine(string.Join(", ", powers))
                .ToString();
        }
    }
}