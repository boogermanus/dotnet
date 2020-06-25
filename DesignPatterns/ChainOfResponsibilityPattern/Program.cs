using System;
using ChainOfResponsibilityPattern.Client;
using ChainOfResponsibilityPattern.ConcreteHandler;
using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;
using ChainOfResponsibilityPattern.Model.Villain;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client();
            Hero();
        }

        static void Client()
        {
            Approver jordan = new GeneralManager(null);
            Approver haley = new PurchasingManager(jordan);
            Approver betsy = new HeadChef(haley);

            PurchaseOrder po1 = new PurchaseOrder("Spices", 20, 3.50m);
            betsy.ProcessRequest(po1);
            Console.WriteLine(po1);

            PurchaseOrder po2 = new PurchaseOrder("Fresh Veggies", 300, 8);
            betsy.ProcessRequest(po2);
            Console.WriteLine(po2);

            PurchaseOrder po3 = new PurchaseOrder("Beef", 500, 9.23m);
            betsy.ProcessRequest(po3);
            Console.WriteLine(po3);

            PurchaseOrder po4 = new PurchaseOrder("Ovens", 5, 5000.21m);

            try
            {
                betsy.ProcessRequest(po4);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(po4);
            }
        }

        static void Hero()
        {
            var gothamCity = new GothamCity();

            var poisonIvy = new PoisonIvy();
            gothamCity.HandleVillain(poisonIvy);
            Console.WriteLine(poisonIvy);

            var clayface = new Clayface();
            gothamCity.HandleVillain(clayface);
            Console.WriteLine(clayface);

            var joker = new Joker();
            gothamCity.HandleVillain(joker);
            Console.WriteLine(joker);

            try
            {
                var bane = new Bane();
                gothamCity.HandleVillain(bane);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
