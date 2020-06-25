
using ChainOfResponsibilityPattern.Handler;

namespace ChainOfResponsibilityPattern.Model.Villain
{
    public abstract class BaseVillain : BaseEntity
    {
        public Hero HandledBy {get;set;}
        public BaseVillain(string name) : base(name) {}
        public override string ToString()
        {
            return $"{Name} was handled by {HandledBy.Name}";
        }
    }
}