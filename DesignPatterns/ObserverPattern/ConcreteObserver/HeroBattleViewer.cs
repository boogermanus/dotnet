using System;
using ObserverPattern.Subject;

namespace ObserverPattern.ConcreteObserver
{
    public class HeroBattleViewer : IObserver<Hero>
    {
        private string _name;

        public HeroBattleViewer(string name)
        {
            _name = name;
        }

        public void OnCompleted()
        {
            Console.WriteLine($"{_name}: The hero battle has completed!");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{_name}: {error.Message}");
        }

        public void OnNext(Hero value)
        {
            Console.WriteLine($"{_name}: {value}");
        }
    }
}