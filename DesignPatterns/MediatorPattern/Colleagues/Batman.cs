using MediatorPattern.Mediators;

namespace MediatorPattern.Colleagues
{
    public class Batman : Hero
    {
        public Batman(IHeroMediator mediator) : base(mediator) {}
    }
}