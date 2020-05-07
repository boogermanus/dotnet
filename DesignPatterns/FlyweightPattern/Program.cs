using System;
using FlyweightPattern.Flyweight;
using FlyweightPattern.FlyweightFactory;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Sliders();
        }

        static void Sliders()
        {
            // Build a slider order using patron's input
            Console.WriteLine(
                "Please enter your slider order (use characters B, V, Q with no spaces):"
            );
            var order = Console.ReadLine();
            char[] chars = order.ToCharArray();
            SliderFactory factory = new SliderFactory();
            int orderTotal = 0;
            //Get the slider from the factory
            foreach (char c in chars)
            {
                orderTotal++;
                Slider character = factory.GetSlider(c);
                character.Display(orderTotal);
            }
            Console.ReadKey();
        }
    }
}
