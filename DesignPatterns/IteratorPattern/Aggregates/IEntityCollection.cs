using IteratorPattern.Iterators;
using IteratorPattern.Models;

namespace IteratorPattern.Aggregates
{
    public interface IEntityCollection
    {
        IEntityIterator CreateIterator();
        int Count { get; }
        Entity this[int index] {get; set;}
        void Add(Entity entity);
    }
}