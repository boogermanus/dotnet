using System.Collections.Generic;
namespace FacadePattern.Models
{
    public class HeroCollection
    {
        private List<Hero> _heros = new List<Hero>();
        public List<Hero> Heros => _heros;

        public HeroCollection()
        {
            _heros.AddRange(new []{
                new Hero(1, "Superman"),
                new Hero(2, "Batman"),
                new Hero(3, "Wonder Women"),
                new Hero(4, "Flash"),
                new Hero(5, "Green Lantern"),
                new Hero(6, "Martian Manhunter")
            });
        }
    }
}