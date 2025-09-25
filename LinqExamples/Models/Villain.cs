using System;

namespace LinqExamples.Models
{
    public class Villain : BaseCharacter, IHero, IEquatable<Villain>
    {
        public string Hero { get; set; }
        
        public override string ToString()
        {
            return $"Villain: {Name} - {PowerLevel}";
        }
        
        public bool Equals(Villain other)
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
        
    }
}