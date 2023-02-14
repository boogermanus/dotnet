namespace Fundamentals
{
    public class EqualClass
    {
        public EqualClass(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is EqualClass target))
                return false;
            
            return Equals(Name, target.Name);
        }
            
        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }

    }
}