using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.Handler
{
    public abstract class Hero : BaseEntity
    {
        public Hero(string name): base(name) {}
    }
}