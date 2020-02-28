using FactoryMethodPattern.Powers;
namespace FactoryMethodPattern.Heroes
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