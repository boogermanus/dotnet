using System;
using BuilderPattern.Builder;
using BuilderPattern.ConcreteBuilder;
using BuilderPattern.Director;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AvengerBuilder builder;
            Avengers avengers = new Avengers();

            builder = new CaptainAmerica();
            avengers.Assemble(builder);

            Console.Write(builder.Avenger.ToString());

            builder = new BlackWidow();
            avengers.Assemble(builder);

            Console.Write(builder.Avenger.ToString());

            avengers.Assemble(new [] { (AvengerBuilder)new CaptainAmerica(), (AvengerBuilder)new BlackWidow()});

            Console.ReadKey();
        }
    }
}
