using System;
using BridgePattern.Abstraction;
using BridgePattern.ConcreteImplementer;
using BridgePattern.RefinedAbstraction;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SendOrder order = new SendDairyFreeOrder()
            {
                Restaurant = new DinerOrders()
            };

            order.Send();

            order.Restaurant = new FancyRestaurantOrders();
            order.Send();

            order = new SendGlutenFreeOrder()
            {
                Restaurant = new DinerOrders()
            };
            order.Send();

            order.Restaurant = new FancyRestaurantOrders();
            order.Send();

            Console.ReadKey();
        }
    }
}
