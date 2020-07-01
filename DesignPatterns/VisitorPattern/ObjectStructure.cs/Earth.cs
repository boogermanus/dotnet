using VisitorPattern.ConcreteElement;
using VisitorPattern.ConcreteVisitor;
using VisitorPattern.Visitor;

namespace VisitorPattern.ObjectStructure
{
    public class Earth : Planet
    {
        public Earth() : base("Earth", 7000000000) { }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is PopulationControl)
            {
                visitor.Visit(this);
                _log.Add($"{Name} doesn't accept {visitor.GetType().Name} - Population {Population:n}");
            }
            else
            {
                base.Accept(visitor);
            }
        }
    }
}