using VisitorPattern.ConcreteElement;
using VisitorPattern.Visitor;

namespace VisitorPattern.ConcreteVisitor
{
    public class IncomeVisitor : IVisitor
    {
        public void Visit(Element.Element element)
        {
            var employee = element as Employee;

            employee.AnnualSalary *= 1.10m;
        }
    }
}