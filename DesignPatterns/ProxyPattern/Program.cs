using System;
using ProxyPattern.Proxy;
using ProxyPattern.RealSubject;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Servers();
            Heroes();
        }

        static void Servers()
        {
            var proxy = new NewServerProxy();

            proxy.TakeOrder("Steak");
            Console.WriteLine($"Order delivered: {proxy.DeliverOrder()}");
            proxy.ProcessPayment("$25.99");
        }

        static void Heroes()
        {
            var robin = new Robin();
            var batman = new Batman(robin);
            var joker = new Joker();
            var harleyQuinn = new HarleyQuinn();

            batman.Goto("Bludhaven");
            batman.Fight(harleyQuinn);
            batman.Fight(joker);
            batman.Goto("Hall of Justice");
        }
    }
}
