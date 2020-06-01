using StatePattern.Constants;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Poor : Health
    {
        public Poor(Health health) : base(health) {}

        public override void CheckHealth()
        {
            if (HitPoints >= HealthConstants.Poor)
                Hero.Health = new Poor(Hero.Health);
            if (HitPoints >= HealthConstants.Fair)
                Hero.Health = new Fair(Hero.Health);
            if (HitPoints >= HealthConstants.Good)
                Hero.Health = new Good(Hero.Health);
            if (HitPoints >= HealthConstants.Excellent)
                Hero.Health = new Excellent(Hero.Health);
            if(HitPoints <= HealthConstants.Dead)
                Hero.Health = new Dead(Hero.Health);

        }
    }
}