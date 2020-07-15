using System;
using MediatorPattern.Colleagues;
using MediatorPattern.ConcreteMediators;
using MediatorPattern.Models;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Concessions();
            Heroes();
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

        static void Heroes()
        {
            var mediator = new TowerOfJustice();
            var batman = new Batman(mediator);
            var superman = new Superman(mediator);
            var robin = new Robin(mediator);

            superman.send(new HeroMessage("Help needed in Metropolis!", batman, robin));
            batman.send(new HeroMessage("On the way to Metropolis!", superman));

            batman.send(new HeroMessage("Help needed in Gotham City!", superman, robin));
            superman.send(new HeroMessage("On the way to Gotham City!", batman));
            robin.send(new HeroMessage("On the way!", batman));
        }
    }
}
