using BridgePattern.Abstraction;

namespace BridgePattern.RefinedAbstraction
{
    public class SendDairyFreeOrder : SendOrder
    {
        public override void Send()
        {
            Restaurant.PlaceOrder("Dairy-Free");
        }
    }
}