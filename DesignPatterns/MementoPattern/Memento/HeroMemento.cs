using System.Collections.Generic;
using MementoPattern.Originator;

namespace MementoPattern.Memento
{
    public class HeroMemento
    {
        private Dictionary<string, object> _data;
        public Dictionary<string, object> Data => _data;

        public HeroMemento(Hero hero)
        {
            // you have to make a copy of the data
            _data = new Dictionary<string, object>(hero.Data);
        }
    }
}