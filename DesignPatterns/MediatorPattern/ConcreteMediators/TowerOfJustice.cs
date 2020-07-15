using System.Collections.Generic;
using MediatorPattern.Colleagues;
using MediatorPattern.Mediators;

namespace MediatorPattern.ConcreteMediators
{
    public class TowerOfJustice : IHeroMediator
    {
        public void SendMessage(Hero sender, string message, Hero target)
        {
            if(target.canNotify(sender))
            {
                target.notify(message);
            }
        }
    }
}