using TemplateMethodPattern.AbstractClasses;

namespace TemplateMethodPattern.ConcreteClasses
{
    public class Superman : HeroBase
    {
        protected override string Name => nameof(Superman);

        protected override string City => "Metropolsis";

        public override void MakeHero()
        {
            _powers.Add("Flight");
            _powers.Add("Invulnerable");
            _powers.Add("Heat Vision");
            _powers.Add("Strength");
        }
    }
}