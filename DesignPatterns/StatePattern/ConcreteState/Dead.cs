using StatePattern.Constants;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Dead : Health
    {
        public Dead(Health health) : base(health) {}

        public override void CheckHealth()
        {
           Hero.Health = new Dead(Hero.Health);
        }
    }
}