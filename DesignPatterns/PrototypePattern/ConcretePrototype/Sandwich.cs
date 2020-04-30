using System;
using System.Text;
using PrototypePattern.Prototype;

namespace PrototypePattern.ConcretePrototype
{
    public class Sandwich : SandwichPrototype
    {
        private string _bread;
        private string _meat;
        private string _cheese;
        private string _veggies;

        public Sandwich(params string[] ingredientsList)
        {
            if(ingredientsList.Length < 4)
                throw new ArgumentException("Invalid number of ingredients", nameof(ingredientsList));

            _bread = ingredientsList[0];
            _meat = ingredientsList[1];
            _cheese = ingredientsList[2];
            _veggies = ingredientsList[3];
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Cloning sandwhich with ingredients: {this.ToString()}");

            return MemberwiseClone() as SandwichPrototype;
        }

        public override string ToString()
        {
            return new StringBuilder()
            .AppendLine(_bread)
            .AppendLine(_meat)
            .AppendLine(_cheese)
            .AppendLine(_veggies)
            .ToString();
        }
    }
}