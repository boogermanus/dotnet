
using ChainOfResponsibilityPattern.Handler;

namespace ChainOfResponsibilityPattern.Model.Villain
{
    public abstract class Villain : BaseEntity
    {
        public Hero HandledBy {get;set;}
        public Villain(string name) : base(name) {}
    }
}