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

        public void Display(int orderTotal)
        {
            Console.WriteLine(GetDisplayString(orderTotal));
        }

        private string GetDisplayString(int total) 
        {
            return new StringBuilder()
                .AppendLine($"{SLIDER_NUMBER}{total}: ")
                .AppendLine($"{Name}${TOPPED_WITH}")
                .AppendLine($"{Cheese}{CHEESE_WITH}")
                .AppendLine($"{Toppings}! ${Price}")
                .ToString();
        }
    }
}