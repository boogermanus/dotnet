using FactoryMethodPattern.ConcreteProduct;
using FactoryMethodPattern.ConcreteProductProduct;

namespace FactoryMethodPattern.ConcreteCreator
{
    public class Superman : Hero
    {
        public override string Name => nameof(Superman);

        public override void MakeHero()
        {
            Powers.Add(new Flight());
            Powers.Add(new Strength());
            Powers.Add(new Invulnerable());
            Powers.Add(new HeatVision());
        }
    }
}