using System;
using ProxyPattern.Subject;

namespace ProxyPattern.Proxy
{
    public class Batman : IHero
    {
        public string Name => "Batman";

        public string Location { get; set; }
        private IHero _sideKick;

        public Batman(IHero sideKick)
        {
            _sideKick = sideKick;
            Location = "Gotham City";
        }

        public void Fight(IHero hero)
        {
            if(hero.Name.ToLower().Equals("joker"))
            {
                Console.WriteLine($"Batman captures {hero.Name}");
                return;
            }

            _sideKick.Fight(hero);

        }

        public void Goto(string location)
        {
            if(location.ToLower().Equals("hall of justice"))
            {
                Console.WriteLine("Only Batman may travel to the Hall of Justice");
                Location = location;
                return;
            }
            
            _sideKick.Goto(location);
        }
    }
}