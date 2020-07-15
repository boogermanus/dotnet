using MediatorPattern.Colleagues;
using MediatorPattern.Mediators;

namespace MediatorPattern.ConcreteMediators
{
    public class ConcessionsMediator : Mediator
    {
        private NorthConcessionStand _northConcessions;
        public NorthConcessionStand NorthConcessions
        {
            set { _northConcessions = value; }
        }

        private SouthConcessionStand _southConcessions;
        public SouthConcessionStand SouthConcessions
        {
            set { _southConcessions = value; }
        }

        public void SendMessage(string message, ConcessionStand concessionStand)
        {
            if(concessionStand == _northConcessions)
            {
                _southConcessions.notify(message);
            }

            if(concessionStand == _southConcessions)
            {
                _northConcessions.notify(message);
            }
        }
    }
}