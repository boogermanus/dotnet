using FactoryMethodPattern.ConcreteProduct;
using FactoryMethodPattern.Product;
namespace FactoryMethodPattern.ConcreteCreator
{
    public class WonderWomen : Hero
    {
        public override string Name => "Wonder Women";

        public override void MakeHero()
        {
            Powers.Add(new Flight());
            Powers.Add(new Strength());
            Powers.Add(new Invulnerable());
        }
    }
}