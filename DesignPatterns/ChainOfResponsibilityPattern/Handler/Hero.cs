using System;
using ChainOfResponsibilityPattern.Model;
using ChainOfResponsibilityPattern.Model.Villain;

namespace ChainOfResponsibilityPattern.Handler
{
    public abstract class Hero : BaseEntity
    {
        private Hero _subordinate;
        public Hero Subordinate => _subordinate;

        public Hero(string name, Hero mentor) : base(name)
        {
            _subordinate = mentor;
        }

        public virtual void HandleVillain(BaseVillain villain)
        {
            throw new Exception($"{Name} cannot handle {villain}");
        }
    }
}