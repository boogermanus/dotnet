using System.Linq;
using System.Collections.Generic;
using IteratorPattern.Interfaces;
namespace IteratorPattern.Models
{
    // the Concrete Aggregate
    public class CandyCollection : ICandyCollection
    {
        private List<JellyBean> _items = new List<JellyBean>();
        
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