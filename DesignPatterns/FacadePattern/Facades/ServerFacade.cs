using System;
using FacadePattern.Models;
using FacadePattern.Services;
namespace FacadePattern.Facades
{
    public class ServerFacade
    {
        private ColdPrepService _coldPrep = new ColdPrepService();
        private HotPrepService _hotPrep = new HotPrepService();
        private DrinkPrepService _bar = new DrinkPrepService();

        public Order PlaceOrder(Patron patron)
        {
            var order = new Order();

            order.Patron = patron;
            order.Appetizer = _coldPrep.PrepDish(patron.ColdPrepId);
            order.Entree = _hotPrep.PrepDish(patron.HotPrepId);
            order.Drink = _bar.PrepDish(patron.BarPrepId);

            return order;
        }

        public Patron TakeOrder()
        {
            Console.WriteLine("I'll be you server today. What is your name?");
            var patron = new Patron(Console.ReadLine());

            Console.WriteLine($"Hello {patron.Name}");
            Console.WriteLine("What appetizer would you like? (1-3)");
            patron.ColdPrepId = int.Parse(Console.ReadLine());

            Console.WriteLine("What entree would you like? (4-6)");
            patron.HotPrepId = int.Parse(Console.ReadLine());

            Console.WriteLine("What drink would you like? (7-9)");
            patron.BarPrepId = int.Parse(Console.ReadLine());

            Console.WriteLine("I will place your order right away!");

            return patron;
        }
    }
}