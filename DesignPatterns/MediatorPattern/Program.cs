using System;
using MediatorPattern.Colleagues;
using MediatorPattern.ConcreteMediators;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Concessions();
        }

        static void Concessions()
        {
            var mediator = new ConcessionsMediator();
            var north = new NorthConcessionStand(mediator);
            var south = new SouthConcessionStand(mediator);

            mediator.NorthConcessions = north;
            mediator.SouthConcessions = south;

            north.send("Can you send some popcorn?.");
            south.send("Sure thing, Kenny's on his way.");

            south.send("Do you have any extra hot dogs? We've had a rush on them over here.");
            north.send("Just a couple, we'll send Keey back with them.");

            Console.ReadKey();
        }
    }
}
