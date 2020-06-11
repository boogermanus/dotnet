using System;
using ProxyPattern.Subject;

namespace ProxyPattern.RealSubject
{
    public class Robin : IHero
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public Robin()
        {
            Name = "Robin";
            Location = "Gotham City";
        }

        public void Fight(IHero hero)
        {
            Console.WriteLine($"Robin fights {hero.Name}");
        }

        public void Goto(string location)
        {
            Console.WriteLine($"Robin uses the Batcycle to goto {location}");
            Location = location;
        }
    }
}