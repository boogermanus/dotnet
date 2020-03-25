using TemplateMethodPattern.AbstractClasses;

namespace TemplateMethodPattern.ConcreteClasses
{
    public class Superman : HeroTemplate
    {
        public override string Name => nameof(Superman);

        public override string City => "Metropolsis";

        public override void MakeHero()
        {
            _powers.Add("Flight");
            _powers.Add("Invulnerable");
            _powers.Add("Heat Vision");
            _powers.Add("Strength");
        }
    }
}