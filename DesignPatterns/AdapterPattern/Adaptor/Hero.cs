using System;
using AdapterPattern.Adaptee;
using AdapterPattern.Target;

namespace AdapterPattern.Adaptor
{
    public class Hero : HeroBase
    {
        private HeroDatabase _database = new HeroDatabase();

        public Hero(string hero) : base(hero)
        {
        }

        public override void LoadData()
        {
            base.LoadData();
            Name = _database.GetHeroName(Alias);
            City = _database.GetHeroCity(Alias);
            Age = _database.GetHeroAge(Alias);

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"City: {City}");
        }
    }
}