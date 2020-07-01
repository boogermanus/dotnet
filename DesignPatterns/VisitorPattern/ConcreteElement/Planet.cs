using System.Collections.Generic;
using System.Text;
using VisitorPattern.Visitor;

namespace VisitorPattern.ConcreteElement
{
    public class Planet : Element.Element
    {
        public string Name { get; set; }
        public long Population { get; set; }
        protected List<string> _log = new List<string>();

        public Planet(string name, long population)
        {
            Name = name;
            Population = population;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            _log.Add($"{Name} accepted {visitor.GetType().Name} - Population: {Population}");
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Planet: {Name}");
            builder.AppendLine($" Population: {Population}");
            builder.AppendLine($" Events:");

            _log.ForEach(e => builder.AppendLine($"  {e}"));

            return builder.ToString();
        }
    }
}