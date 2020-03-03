using BridgePattern.Abstraction;

namespace BridgePattern.RefinedAbstraction
{
    public class SendGlutenFreeOrder : SendOrder
    {
        public override void Send()
        {
            Restaurant.PlaceOrder("Gluten-Free Order");
        }
    }
}