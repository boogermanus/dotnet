using MediatorPattern.Mediators;

namespace MediatorPattern.Colleagues
{
    public class Robin : Hero
    {
        public Robin(IHeroMediator mediator) : base(mediator) {}

        public override bool canNotify(Hero hero)
        {
            return hero.GetType().Name == nameof(Batman) ? true : false;
        }
    }
}