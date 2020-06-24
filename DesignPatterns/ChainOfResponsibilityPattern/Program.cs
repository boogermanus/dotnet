using System;
using ChainOfResponsibilityPattern.ConcreteHandler;
using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Client();
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(po4);
            }
        }
    }
}
