using System.Text;
using CompositePattern.Composits;

namespace CompositePattern.Clients
{
    public class DrinkDispenser
    {
        public Cola Colas { get; set; }
        public Beer Beers { get; set; }
        public Other Other { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine("Drinks")
                .AppendLine($"-Cola {Colas.Display(2)}")
                .AppendLine($"-Beer {Beers.Display(2)}")
                .AppendLine($"-Other {Other.Display(2)}")
                .ToString();
        }
    }
}