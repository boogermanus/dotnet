using System;
namespace IteratorPattern.Interfaces
{
    // the Aggregate
    public interface ICandyCollection
    {
        IJellyBeanIterator CreateIterator();
    }
}