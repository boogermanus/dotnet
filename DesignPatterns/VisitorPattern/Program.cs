using System;
using VisitorPattern.ConcreteVisitor;
using VisitorPattern.ObjectStructure;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Employees();
        }

        static void Employees()
        {
            var employees = new Employees();
            employees.Attach(new LineCook());
            employees.Attach(new HeadChef());
            var gm = new GeneralManager();
            employees.Attach(gm);

            employees.Accept(new IncomeVisitor());
            
            employees.Detach(gm);

            employees.Accept(new PaidTimeOffVisitor());
        }
    }
}
