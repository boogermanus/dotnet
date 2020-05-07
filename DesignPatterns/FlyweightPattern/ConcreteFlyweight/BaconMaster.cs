using FlyweightPattern.Flyweight;

namespace FlyweightPattern.ConcreteFlyweight
{
    public class BaconMaster : Slider
    {
        public BaconMaster()
        {
            Name = "Bacon Master";
            Cheese = "American";
            Toppings = "lots of bacon";
            Price = 2.39m;
        }
    }
}