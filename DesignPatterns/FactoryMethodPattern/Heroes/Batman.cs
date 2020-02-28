using FactoryMethodPattern.Powers;
namespace FactoryMethodPattern.Heroes
{
    public class Batman : Hero
    {
        public override string Name => nameof(Batman);

        public override void MakeHero()
        {
            Powers.Add(new IsBatman());
        }
    }
}