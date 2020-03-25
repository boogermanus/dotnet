using IteratorPattern.ConcreteAggregates;
using IteratorPattern.Iterators;
using IteratorPattern.Models;

namespace IteratorPattern.ConcreteIterators
{
    public class EntityIterator : IEntityIterator
    {
        private int _current = 0;
        private const int STEP = 1;
        private EntityCollection _collection;
        public bool IsDone => _current >= _collection.Count;
        public Entity Current => _collection[_current];

        public EntityIterator(EntityCollection collection)
        {
            _collection = collection;
        }

        public Entity First()
        {
            _current = 0;
            return _collection[_current];
        }

        public Entity Next()
        {
            _current += STEP;

            return !IsDone ? _collection[_current] : null;
        }
    }
}