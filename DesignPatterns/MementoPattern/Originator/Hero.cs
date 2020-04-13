using System.Linq;
using System.Collections.Generic;
using MementoPattern.Memento;

namespace MementoPattern.Originator
{
    public class Hero
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>
        {
            {"Name", null},
            {"Mission", null},
            {"Location", null}
        };

        public Dictionary<string, object> Data => _data;

        public object this[string key]
        {
            get => _data[key];
            set => _data[key] = value;
        }

        public string Name
        {
            get => _data[nameof(Name)].ToString();
            set => _data[nameof(Name)] = value;
        }

        public string Mission
        {
            get => _data[nameof(Mission)].ToString();
            set => _data[nameof(Mission)] = value;
        }

        public string Location
        {
            get => _data[nameof(Location)].ToString();
            set => _data[nameof(Location)] = value;
        }

        public override string ToString()
        {
            return $"I'm {Name}, and I'm in {Location} on a mission to {Mission}!";
        }

        public HeroMemento SaveHero()
        {
            return new HeroMemento(this);
        }

        public Hero RestoreHero(HeroMemento memento)
        {
            var keys = _data.Keys.Cast<string>().ToList();

            foreach (var key in keys)
            {
                this[key] = memento.Data[key];
            }

            return this;
        }
    }
}