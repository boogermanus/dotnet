using FactoryMethodPattern.Powers;
namespace FactoryMethodPattern.Heroes
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