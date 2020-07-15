using MediatorPattern.Mediators;

namespace MediatorPattern.Colleagues
{
    public class Superman : Hero
    {
        public Superman(IHeroMediator mediator) : base(mediator) {}
    }
}