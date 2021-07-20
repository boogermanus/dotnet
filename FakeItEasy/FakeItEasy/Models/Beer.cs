using System;
using System.Text;

namespace FakeItEasy.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public decimal Abv { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Id: {Id}\tName: {Name}");
            builder.AppendLine($"ABV {Abv}");
            builder.AppendLine($"Description: {Description}");
            builder.AppendLine($"Tagline: {Tagline}");
            builder.AppendLine("-------------");
            return builder.ToString();
        }
    }
}