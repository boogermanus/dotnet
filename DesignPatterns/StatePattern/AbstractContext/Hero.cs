using System;
using System.Text;
using StatePattern.State;

namespace StatePattern.AbstractContext
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public Health Health { get; set; }
        public int AttackPower = 1;
        public int HealPower = 1;

        public Hero(string name)
        {
            Name = name;
        }

        public void Attack(Hero hero)
        {
            hero.Health.TakeDamage(AttackPower);
            var status = new StringBuilder()
                .AppendLine($"{Name} is attacked by {hero.Name} and takes {AttackPower} damage")
                .AppendLine($"Current Health is {Health.HitPoints}")
                .AppendLine($"Health Status is {Health.GetType().Name}")
                .ToString();
            Console.WriteLine(status);
        }

        public void Heal()
        {
            Health.Heal(HealPower);
            var status = new StringBuilder()
            .AppendLine($"{Name} heals by {HealPower}")
            .AppendLine($"Current Health is {Health.HitPoints}")
            .AppendLine($"Health Status is {Health.GetType().Name}")
            .ToString();
            Console.WriteLine(status);
        }
    }
}