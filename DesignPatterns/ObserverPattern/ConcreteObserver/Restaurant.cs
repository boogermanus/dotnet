using System;
using ObserverPattern.Observer;
using ObserverPattern.Subject;

namespace ObserverPattern.ConcreteObserver
{
    public class Restaurant : IRestaurant
    {
        private string _name;
        private double _purchaseThreshold;

        public Restaurant(string name, double threshold)
        {
            _name = name;
            _purchaseThreshold = threshold;
        }

        public void Update(Veggies veggie)
        {
            Console.WriteLine(
                $"Notified {_name} of {veggie.GetType().Name} price change to {veggie.PricePerPound:C} per pound.");

            if(veggie.PricePerPound < _purchaseThreshold)
            {
                Console.WriteLine($"{_name} wants to buy some {veggie.GetType().Name}!");
            }
        }
    }
}