using System.Collections.Generic;
using CommandPattern.Commands;

namespace CommandPattern.ConcreteCommands
{
    public class AddCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            currentItems.Add(newItem);
        }
    }

}