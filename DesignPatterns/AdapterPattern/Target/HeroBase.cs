using System;

namespace AdapterPattern.Target
{
    public class HeroBase
    {
        public string Alias;
        public string Name;
        public string City;
        public int Age;

        public HeroBase(string hero)
        {
            Alias = hero;
        }

        public virtual void LoadData()
        {
            Console.WriteLine($"I'm {Alias}");
        }
    }
}