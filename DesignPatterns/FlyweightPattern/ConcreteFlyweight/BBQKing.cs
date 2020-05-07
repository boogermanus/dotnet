using FlyweightPattern.Flyweight;

namespace FlyweightPattern.ConcreteFlyweight
{
    public class BBQKing : Slider
    {
        public BBQKing()
        {
            Name = "BBQ King";
            Cheese = "American";
            Toppings = "Onion rings, lettuce, and BBQ sauce";
            Price = 2.49m;
        }
    }
}