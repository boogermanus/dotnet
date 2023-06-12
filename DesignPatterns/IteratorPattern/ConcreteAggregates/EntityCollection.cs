using System;
using System.Collections.Generic;
using IteratorPattern.Aggregates;
using IteratorPattern.ConcreteIterators;
using IteratorPattern.Iterators;
using IteratorPattern.Models;

namespace IteratorPattern.ConcreteAggregates
{
    public class EntityCollection : IEntityCollection
    {
        private List<Entity> _entities = new List<Entity>();
        public int Count => _entities.Count;

        public IEntityIterator CreateIterator()
        {
            return new EntityIterator(this);
        }

        public void Add(Entity entity)
        {
            _entities.Add(entity);
        }

        public Entity this[int index]
        {
            get => _entities[index];
            set => _entities.Add(value);
        }
    }
}