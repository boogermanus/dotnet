using StatePattern.State;

namespace StatePattern.AbstractContext
{
    public abstract class Hero
    {
        public string Name {get;set;}
        public Health Health {get;set;}

        public Hero(string name)
        {
            Name = name;
        }
    }
}