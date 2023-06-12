using IteratorPattern.Iterators;

namespace IteratorPattern.Aggregates
{
    // the Aggregate
    public interface ICandyCollection
    {
        IJellyBeanIterator CreateIterator();
    }
}