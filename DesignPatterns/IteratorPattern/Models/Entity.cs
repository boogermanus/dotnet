namespace IteratorPattern.Models
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}