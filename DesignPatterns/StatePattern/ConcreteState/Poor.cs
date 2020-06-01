using StatePattern.Constants;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Poor : Health
    {
        public Poor(int hitPoints) : base(hitPoints) {}

        public override void CheckHealth()
        {
            if (HitPoints >= HealthConstants.Poor)
                Hero.Health = new Poor(Hero.Health.HitPoints);
            if (HitPoints >= HealthConstants.Fair)
                Hero.Health = new Fair(Hero.Health.HitPoints);
            if (HitPoints >= HealthConstants.Good)
                Hero.Health = new Good(Hero.Health.HitPoints);
            if (HitPoints >= HealthConstants.Excellent)
                Hero.Health = new Excellent(Hero.Health.HitPoints);
            if(HitPoints <= HealthConstants.Dead)
                Hero.Health = new Dead(Hero.Health.HitPoints);

        }
    }
}