using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model.Villain;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class Batgirl : Hero
    {
        public Batgirl(Hero mentor) : base("Bat Girl", mentor) {}

        public override void HandleVillain(BaseVillain villain)
        {
            if(villain is PoisonIvy)
                villain.HandledBy = this;
            else
                base.HandleVillain(villain);
        }
    }
}