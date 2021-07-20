using System;
using System.Linq;
using FakeItEasy.Services;

namespace FakeItEasy
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new BeerService();

            var beers = service.GetBeers();

            beers.ToList().ForEach(Console.WriteLine);

            var beer = service.GetBeer(26);
            Console.WriteLine(beer);
        }
    }
}
