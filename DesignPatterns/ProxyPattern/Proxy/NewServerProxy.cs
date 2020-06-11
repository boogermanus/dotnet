using System;
using ProxyPattern.RealSubject;
using ProxyPattern.Subject;

namespace ProxyPattern.Proxy
{
    public class NewServerProxy : IServer
    {
        private string _order;
        private Server _server = new Server();
        public string DeliverOrder()
        {
            return _order;
        }

        public void ProcessPayment(string payment)
        {
            Console.WriteLine("New trainee cannot process payments yet!");
            _server.ProcessPayment(payment);
        }

        public void TakeOrder(string order)
        {
            Console.WriteLine($"New trainee server takes order {order}");
            _order = order;
        }
    }
}