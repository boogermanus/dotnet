using StatePattern.AbstractContext;
using StatePattern.ConcreteState;

namespace StatePattern.State
{
    public class Superman : Hero
    {
        public Superman() : base("Superman") 
        {
            AttackPower = 25;
            HealPower = 10;
            Health = new Excellent(100);
            Health.Hero = this;
        }
    }
}