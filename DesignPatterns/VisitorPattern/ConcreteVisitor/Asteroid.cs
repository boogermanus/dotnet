using System;
using VisitorPattern.ConcreteElement;
using VisitorPattern.Visitor;

namespace VisitorPattern.ConcreteVisitor
{
    public class Asteroid : IVisitor
    {
        public void Visit(Element.Element element)
        {
            var random = new Random();

            var planet = element as Planet;

            planet.Population -= (long)(planet.Population * 0.98);
        }
    }
}