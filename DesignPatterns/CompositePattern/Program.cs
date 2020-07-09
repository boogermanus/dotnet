using System;
using CompositePattern.Clients;
using CompositePattern.Leaves;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DrinkDispenser();
            client.Colas.Add(new NukaCola());
            client.Colas.Add(new Slurm());
            client.Beers.Add(new DuffBeer());
            client.Beers.Add(new AlamoBeer());
            client.Other.Add(new ButterBeer());

            Console.WriteLine(client.ToString());
        }
    }
}
