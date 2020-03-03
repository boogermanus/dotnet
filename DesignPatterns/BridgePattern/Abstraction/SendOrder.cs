using BridgePattern.Implementer;
namespace BridgePattern.Abstraction
{
    public abstract class SendOrder
    {
        public IOrderingSystem Restaurant;

        public abstract void Send();
    }
}