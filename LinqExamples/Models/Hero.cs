using System;

namespace LinqExamples.Models
{
    public class Hero : IHero, IEquatable<Hero>
    
    {
        public string Name { get; set; }
        public decimal PowerLevel { get; set; }
        public string[] Powers { get; set; }
        public bool IsVillain { get; set; }
        public string Team { get; set; }

        public Hero()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"Hero: {Name} - {PowerLevel}";
        }

        public bool Equals(Hero other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && PowerLevel == other.PowerLevel;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Hero) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, PowerLevel);
        }
    }
}