using FlyweightPattern.Flyweight;

namespace FlyweightPattern.ConcreteFlyweight
{
    public class Veggie : Slider
    {
        public Veggie()
        {
            Name = "Veggie";
            Cheese = "Swiss";
            Toppings = "lettuce, onion, tomato, and pickles";
            Price = 1.99m;
        }
    }
}