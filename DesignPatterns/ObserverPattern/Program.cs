using System;
using ObserverPattern.ConcreteObserver;
using ObserverPattern.ConcreteSubject;
using ObserverPattern.Subject;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carrots();
            Heroes();
        }

        static void Carrots()
        {
            // Create price watch for Carrots and attach restaurants
            // that buy carrots from suppliers.
            Carrots carrots = new Carrots(0.82);
            carrots.Attach(new Restaurant("Mackay's", 0.77));
            carrots.Attach(new Restaurant("Johnny's Sports Bar", 0.74));
            carrots.Attach(new Restaurant("Salad Kingdom", 0.75));
            // Fluctuating carrot prices will notify subscribing restaurants.
            carrots.PricePerPound = 0.79;
            carrots.PricePerPound = 0.76;
            carrots.PricePerPound = 0.74;
            carrots.PricePerPound = 0.81;
            Console.ReadKey();

        }

        static void Heroes()
        {
            var tracker = new HeroBattleTracker();
            var jimmyOleson = new HeroBattleViewer("Jimmy Olsen");
            tracker.Subscribe(jimmyOleson);

            tracker.AddHero(new Hero("Batman", "POW"));

            tracker.Subscribe(new HeroBattleViewer("Lois Lane"));

            tracker.AddHero(new Hero("Flash", "ZOOM"));

            // one way to unsubscribe
            tracker.Unsubscribe(jimmyOleson);

            // another subscription example
            var perryWhite = new HeroBattleViewer("Perry White");
            perryWhite.Subscribe(tracker);

            tracker.AddHero(null);

            perryWhite.Unsubscribe();

            tracker.AddHero(new Hero("Green Lantern", "GREEN"));

            tracker.Dispose();
            Console.ReadKey();
        }
    }
}
