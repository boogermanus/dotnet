using StatePattern.Constants;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Good : Health
    {
        public Good(int hitPoints) : base(hitPoints) {}

        public override void CheckHealth()
        {
            if (HitPoints >= HealthConstants.Good)
                Hero.Health = new Good(Hero.Health.HitPoints);
            if (HitPoints >= HealthConstants.Excellent)
                Hero.Health = new Excellent(Hero.Health.HitPoints);
            if(HitPoints < HealthConstants.Good)
                Hero.Health = new Fair(Hero.Health.HitPoints);

        }
    }
}