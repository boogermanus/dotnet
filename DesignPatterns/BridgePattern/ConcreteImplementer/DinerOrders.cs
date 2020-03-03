using System;
using BridgePattern.Implementer;

namespace BridgePattern.ConcreteImplementer
{
    public class DinerOrders : IOrderingSystem
    {
        public void PlaceOrder(string order)
        {
            Console.WriteLine($"Placing Order for {order} at the Diner.");
        }
    }
}