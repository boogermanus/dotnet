using System;
using FacadePattern.Facades;
using FacadePattern.Models;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // old and busted
            PlaceOrder();

            //GetHeroTeam();
        }

        static void PlaceOrder()
        {
            var server = new ServerFacade();
            var order = server.PlaceOrder(server.TakeOrder());

            Console.WriteLine(order);
        }

        static void GetHeroTeam()
        {
            var facade = new HeroTeamFacade();
            Console.WriteLine(facade.GetHeroTeam(HeroConfig.GetConfig()));
        }
    }
}
