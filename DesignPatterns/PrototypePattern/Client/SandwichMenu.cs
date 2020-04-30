using System.Linq;
using System.Collections.Generic;
using PrototypePattern.ConcretePrototype;
using PrototypePattern.Prototype;
using System;

namespace PrototypePattern.Client
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> _sandwiches = new Dictionary<string, SandwichPrototype>
        {
            {"BLT", new Sandwich("Wheat", "Bacon", string.Empty, "Lettuce, Tomato")},
            {"PB&J", new Sandwich("White", string.Empty, string.Empty, "Peanut Butter, Jelly")},
            {"Turkey", new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato")},
            {"LoadedBLT", new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives")},
            {"ThreeMeatCombo", new Sandwich("Rye", "Turkey, Hame, Salmi", "Provolone", "Lettuce, Onion")},
            {"Vegetarian", new Sandwich("Wheat", string.Empty, string.Empty, "Lettuce, Onion, Tomato, Olives, Spinach")}
        };

        public SandwichPrototype this[string name]
        {
            get
            {
                var sandwich = _sandwiches.FirstOrDefault(sandwich => sandwich.Key.ToLower() == name.ToLower());

                if(sandwich.Key == null)
                    throw new Exception($"Unable to find Sandwich: {name}");

                return sandwich.Value;
            }
        }
    }
}