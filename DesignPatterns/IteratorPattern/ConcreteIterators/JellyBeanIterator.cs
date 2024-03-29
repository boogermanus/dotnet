using IteratorPattern.Iterators;
using IteratorPattern.Models;
using IteratorPattern.ConcreteAggregates;

namespace IteratorPattern.ConcreteIterators
{
    // the ConcreteIterator
    public class JellyBeanIterator : IJellyBeanIterator
    {
        private readonly CandyCollection _candyCollection;
        private int _current = 0;
        private const int STEP = 1;

        public bool IsDone => _current >= _candyCollection.Count;

        public JellyBean CurrentBean => _candyCollection[_current];

        public JellyBeanIterator(CandyCollection collection)
        {
            _candyCollection = collection;
        }

        public JellyBean First()
        {
            _current = 0;
            return _candyCollection[_current];
        }

        public JellyBean Next()
        {
            _current += STEP;
            return !IsDone ? _candyCollection[_current] : null;
        }
    }
}