using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FactoryMethodPattern.Powers;

namespace FactoryMethodPattern
{
    public abstract class Hero
    {
        public abstract string Name { get; }
        public abstract List<PowerBase> Powers { get; }
        
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