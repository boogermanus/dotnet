using System.Text;

namespace BuilderPattern.Product
{
    public class Avenger
    {
        public string Name {get;set;}
        public string Alias {get;set;}
        public string[] Powers {get;set;}

        public override string ToString()
        {
            return new StringBuilder()
            .AppendLine($"I'm {Name}!")
            .AppendLine($"My real name is: {Alias}")
            .Append("My Powers include: ")
            .AppendJoin(',', Powers)
            .AppendLine()
            .ToString();
        }
    }
}