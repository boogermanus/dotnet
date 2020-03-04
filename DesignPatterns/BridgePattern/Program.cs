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
            // Food();

            Hero();
        }

        static void Hero()
        {
            Announcer announcer = new CentralCity()
            {
               Hero = new Flash()
               // no side kick, no problem
            };

            announcer.Announce();

            announcer = new GothamCity()
            {
                Hero = new Batman(),
                SideKick = new Robin(),
            };

            announcer.Announce();
        }

        static void Food()
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
