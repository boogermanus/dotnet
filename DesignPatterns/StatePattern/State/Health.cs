using StatePattern.AbstractContext;

namespace StatePattern.State
{
    public abstract class Health
    {
        public Hero Hero { get; set; }
        public int HitPoints { get; set; }

        public Health(int amount)
        {
            HitPoints = amount;
        }

        public Health(Health health)
        {
            HitPoints = health.HitPoints;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        public void Heal(int amount)
        {
            HitPoints -= amount;
        }

        public abstract void CheckHealth();

    }
}