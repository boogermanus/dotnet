using System;
using ProxyPattern.Subject;

namespace ProxyPattern.RealSubject
{
    public class HarleyQuinn : IHero
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public HarleyQuinn()
        {
            Name = "Harley Quinn";
            Location = "Gotham City";
        }

        public void Fight(IHero hero)
        {
            Console.WriteLine($"Harley Quinn fights {hero.Name}");
        }

        public void Goto(string location)
        {
            Console.WriteLine($"HarleyQuinn rides hyenas to goto {location}");
            Location = location;
        }
    }
}