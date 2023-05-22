using System;

namespace AdapterPattern.Target
{
    public class HeroBase
    {
        protected string Alias;
        protected string Name;
        protected string City;

        protected int Age;
        // can easily add a field
        // without breaking anything
        public string[] Powers;

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