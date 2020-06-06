using System;
using ProxyPattern.Subject;

namespace ProxyPattern.RealSubject
{
    public class Server : IServer
    {
        private string _order;

        public string DeliverOrder()
        {
            return _order;
        }

        public void ProcessPayment(string payment)
        {
            Console.WriteLine($"Payment for order {payment} processed.");
        }

        public void TakeOrder(string order)
        {
            Console.WriteLine($"Server takes order for {order}.");
            _order = order;
        }
    }
}