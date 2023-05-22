using FactoryMethodPattern.ConcreteProduct;

namespace FactoryMethodPattern.ConcreteCreator
{
    public class Flash : Hero
    {
        public override string Name => "Flash";

        public override void MakeHero()
        {
            Powers.Add(new Speed());
            Powers.Add(new Regeneration());
        }
    }
}