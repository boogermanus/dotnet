namespace VisitorPattern.Visitor
{
    public interface IVisitor
    {
        void Visit(Element.Element element);
    }
}