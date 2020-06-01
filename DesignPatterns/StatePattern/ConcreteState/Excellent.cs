using StatePattern.Constants;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Excellent : Health
    {
        public Excellent(int hitPoints) : base(hitPoints) {}
        public Excellent(Health health) : base(health) {}

        public override void CheckHealth()
        {
            if (HitPoints >= HealthConstants.Excellent)
                Hero.Health = new Excellent(Hero.Health);
            if(HitPoints < HealthConstants.Excellent)
                Hero.Health = new Good(Hero.Health);

        }
    }
}