using VisitorPattern.ConcreteElement;
using VisitorPattern.Visitor;

namespace VisitorPattern.ConcreteVisitor
{
    public class PaidTimeOffVisitor : IVisitor
    {
        public void Visit(Element.Element element)
        {
            var employee = element as Employee;

            employee.PaidTimeOffDays += 3;
        }
    }
}