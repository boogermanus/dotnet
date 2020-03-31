using System;
using System.Collections.Generic;

namespace ObserverPattern.Subject
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<Hero>> _observers;
        private IObserver<Hero> _observer;

        public Unsubscriber(List<IObserver<Hero>> observers, IObserver<Hero> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}