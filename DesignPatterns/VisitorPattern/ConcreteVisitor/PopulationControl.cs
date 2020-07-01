using System;
using VisitorPattern.ConcreteElement;
using VisitorPattern.Visitor;

namespace VisitorPattern.ConcreteVisitor
{
    public class PopulationControl : IVisitor
    {
        public void Visit(Element.Element element)
        {
            var random = new Random();

            var planet = element as Planet;

            planet.Population += (long)(planet.Population * (random.Next(1, 25) / 100m));
        }
    }
}