using System;
using ProxyPattern.Subject;

namespace ProxyPattern.RealSubject
{
    public class Joker : IHero
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public Joker()
        {
            Name = "Joker";
            Location = "Gotham City";
        }

        public void Fight(IHero hero)
        {
            Console.WriteLine($"Joker fights {hero.Name}");
        }

        public void Goto(string location)
        {
            Console.WriteLine($"Joker rides hyenas to goto {location}");
            Location = location;
        }
    }
}