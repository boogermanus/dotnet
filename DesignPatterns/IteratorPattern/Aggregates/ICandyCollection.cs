using IteratorPattern.Iterators;

namespace IteratorPattern.Aggragates
{
    // the Aggregate
    public interface ICandyCollection
    {
        IJellyBeanIterator CreateIterator();
    }
}