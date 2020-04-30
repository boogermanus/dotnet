using System.Collections.Generic;
using System.Linq;
using PrototypePattern.ConcretePrototype;

namespace PrototypePattern.Client
{
    public class JusticeLeague
    {
        private Dictionary<string, Hero> _heroes = new Dictionary<string, Hero>
        {
            {"Superman", new Hero("Superman", "Metropolis")},
            {"Batman", new Hero("Batman", "Gotham City")},
            {"Flash", new Hero("Flash", "Central City")},
        };

        public Hero this[string name] => _heroes.FirstOrDefault(h => h.Key.ToLower() == name.ToLower()).Value;
    }
}