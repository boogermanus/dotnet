using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern.Component
{
    public abstract class RestaurantDish
    {
        private string _name;
        public string Name => _name;

        private Dictionary<string, string> _ingredients;

        public RestaurantDish() {}
        public RestaurantDish(string name, Dictionary<string, string> ingredients)
        {
            _name = name;
            _ingredients = ingredients;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{Name}:");

            foreach(var pair in _ingredients)
            {
                builder.AppendLine($" {pair.Key}: {pair.Value}");
            }

            return builder.ToString();
        }
    }
}