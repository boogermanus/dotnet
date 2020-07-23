using System;
using System.Collections.Generic;
using System.IO;
using CommandPattern.Commands;

namespace CommandPattern.Receivers
{
    public class FastFoodOrder
    {
        private TextWriter _textWriter = Console.Out;
        public List<MenuItem> currentItems { get; set; }
        
        public FastFoodOrder()
        {
            currentItems = new List<MenuItem>();
        }

        public void ExecuteCommand(OrderCommand command, MenuItem item)
        {
            command.Execute(this.currentItems, item);
        }

        public void ShowCurrentItems()
        {
            double total = 0;

            foreach (var item in currentItems)
            {
                item.Display();
                total += item.Total;
            }
            _textWriter.WriteLine("---------------");
            _textWriter.WriteLine($"Total: {Math.Round(total, 2)}");
        }
    }
}