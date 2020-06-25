using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model.Villain;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class Robin : Hero
    {
        public Robin(Hero mentor) : base("Robin", mentor) {}

        public override void HandleVillain(BaseVillain villain)
        {
            if(villain is Clayface)
                villain.HandledBy = this;
            else
                Subordinate.HandleVillain(villain);
        }
    }
}