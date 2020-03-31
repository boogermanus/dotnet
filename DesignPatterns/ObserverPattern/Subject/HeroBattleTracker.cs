using System;
using System.Collections.Generic;

namespace ObserverPattern.Subject
{
    public class HeroBattleTracker : IObservable<Hero>, IDisposable
    {
        private List<IObserver<Hero>> _observers = new List<IObserver<Hero>>();

        public void Dispose()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }

            _observers.Clear();
        }

        public IDisposable Subscribe(IObserver<Hero> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        public IDisposable Unsubscribe(IObserver<Hero> observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer);

            return this;
        }

        public void AddHero(Hero hero)
        {
            foreach(var observer in _observers)
            {
                if(hero != null)
                    observer.OnNext(hero);
                else
                    observer.OnError(new Exception("The hero cannot be determined."));
            }
        }
    }
}