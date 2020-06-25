using System;
using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;
using ChainOfResponsibilityPattern.Model.Villain;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class Batman : Hero
    {
        public Batman(Hero subordinate) : base("Batman", subordinate) {}

        public override void HandleVillain(BaseVillain villain)
        {
            if(villain is Joker)
                villain.HandledBy = this;
            else if(villain is Bane) 
            {
                throw new Exception("Bane brakes Batman's back!");
            }
            else
                Subordinate.HandleVillain(villain);

        }
    }
}