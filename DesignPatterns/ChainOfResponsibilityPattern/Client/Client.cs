using ChainOfResponsibilityPattern.ConcreteHandler;
using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model.Villain;

namespace ChainOfResponsibilityPattern.Client
{
    public class GothamCity
    {
        private Hero _protector;
        public GothamCity()
        {
            var batgirl = new Batgirl(null);
            var robin = new Robin(batgirl);
            var batman = new Batman(robin);
            _protector = batman;
        }

        public void HandleVillain(BaseVillain villain)
        {
            _protector.HandleVillain(villain);
        }
    }
}