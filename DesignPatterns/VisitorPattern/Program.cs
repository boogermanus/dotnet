using System;
using VisitorPattern.ConcreteVisitor;
using VisitorPattern.ObjectStructure;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Employees();
            Earth();
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

        static void Earth() 
        {
            var earth = new Earth();

            earth.Accept(new PopulationControl());
            earth.Accept(new Virus());
            earth.Accept(new Aliens());
            earth.Accept(new Asteroid());

            Console.WriteLine(earth);
        }
    }
}
