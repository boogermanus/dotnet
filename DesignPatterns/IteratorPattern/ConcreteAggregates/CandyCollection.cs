using System.Collections.Generic;
using IteratorPattern.Aggregates;
using IteratorPattern.Iterators;
using IteratorPattern.ConcreteIterators;
using IteratorPattern.Models;

namespace IteratorPattern.ConcreteAggregates
{
    // the Concrete Aggregate
    public class CandyCollection : ICandyCollection
    {
        private readonly List<JellyBean> _items = new List<JellyBean>();
        
        public IJellyBeanIterator CreateIterator()
        {
            return new JellyBeanIterator(this);
        }

        public int Count => _items.Count;

        public JellyBean this[int index]
        {
            get => _items[index];
            set => _items.Add(value);
        }
    }
}