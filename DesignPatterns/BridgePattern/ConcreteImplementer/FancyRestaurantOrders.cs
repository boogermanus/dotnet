using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class FancyRestaurantOrders : IOrderingSystem
    {
        public void PlaceOrder(string order)
        {
            Console.WriteLine($"Placing Order for {order} at the Fancy Restaurant.");
        }
    }
}