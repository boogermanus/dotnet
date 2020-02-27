using System;
using FacadePattern.Facades;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new ServerFacade();
            var order = server.PlaceOrder(server.TakeOrder());

            Console.WriteLine(order);
        }
    }
}
