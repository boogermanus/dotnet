using StatePattern.Constants;
using StatePattern.State;

namespace StatePattern.ConcreteState
{
    public class Dead : Health
    {
        public Dead(int hitPoints) : base(hitPoints) {}

        public override void CheckHealth()
        {
           Hero.Health = new Dead(Hero.Health.HitPoints);
        }
    }
}