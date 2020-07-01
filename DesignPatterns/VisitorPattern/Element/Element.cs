using VisitorPattern.Visitor;

namespace VisitorPattern.Element
{
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}