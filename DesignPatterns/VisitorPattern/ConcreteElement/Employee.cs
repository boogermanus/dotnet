using System.Text;
using VisitorPattern.Visitor;

namespace VisitorPattern.ConcreteElement
{
    public class Employee : Element.Element
    {
        public string Name { get; set; }
        public decimal AnnualSalary { get; set; }
        public int PaidTimeOffDays { get; set; }

        public Employee(string name, decimal salary, int pto)
        {
            Name = name;
            AnnualSalary = salary;
            PaidTimeOffDays = pto;
        }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"{GetType().Name}")
                .AppendLine($" Name: {Name}")
                .AppendLine($" Salary: {AnnualSalary}")
                .AppendLine($" PTO: {PaidTimeOffDays}")
                .ToString();
        }
    }
}