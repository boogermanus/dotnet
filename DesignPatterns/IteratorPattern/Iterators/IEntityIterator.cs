using IteratorPattern.Models;

namespace IteratorPattern.Iterators
{
    public interface IEntityIterator
    {
        bool IsDone { get; }
        Entity First();
        Entity Next();
        Entity Current { get; }
    }
}