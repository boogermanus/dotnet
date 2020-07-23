using System;
using System.IO;
using System.Text;

namespace CommandPattern
{
    public class MenuItem
    {
        private TextWriter _textWriter = Console.Out;
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Total => Amount * Price;

        public MenuItem(string name, int amount, double price)
        {
            Name = name;
            Amount = amount;
            Price = price;
        }

        public void Display()
        {
            _textWriter.Write(new StringBuilder()
                .AppendLine()
                .AppendLine($"Name: {Name}")
                .AppendLine($"Amount {Amount}")
                .AppendLine($"Price: {Price}")
                .ToString());
        }
    }
}