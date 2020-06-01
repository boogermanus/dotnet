using StatePattern.AbstractContext;
using StatePattern.ConcreteState;

namespace StatePattern.State
{
    public class Darkseid : Hero
    {
        public Darkseid() : base("Darkseid") 
        {
            AttackPower = 15;
            HealPower = 10;
            Health = new Excellent(100);
            Health.Hero = this;
        }
    }
}