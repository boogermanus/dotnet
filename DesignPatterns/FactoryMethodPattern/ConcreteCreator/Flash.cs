using FactoryMethodPattern.Product;
namespace FactoryMethodPattern.ConcreteCreator
{
    public class Flash : Hero
    {
        public override string Name => "Wonder Women";

        public override void MakeHero()
        {
            Powers.Add(new Speed());
            Powers.Add(new Regeneration());
        }
    }
}