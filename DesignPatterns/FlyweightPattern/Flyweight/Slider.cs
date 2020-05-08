using System;
using System.Text;

namespace FlyweightPattern.Flyweight
{

    public abstract class Slider
    {
        private const string SLIDER_NUMBER = "Slider #";
        private const string TOPPED_WITH = " - topped with ";
        private const string CHEESE_WITH = " cheese and";

        protected string Name;
        protected string Cheese;
        protected string Toppings;
        protected decimal Price;
        public int OrderId;

        public override string ToString()
        {
                return new StringBuilder()
                .AppendLine($"{SLIDER_NUMBER}{OrderId}: ")
                .AppendLine($"{Name}${TOPPED_WITH}")
                .AppendLine($"{Cheese}{CHEESE_WITH}")
                .AppendLine($"{Toppings}! ${Price}")
                .ToString();
        }
    }
}