using System.Collections.Generic;
using System.Linq;
using CommandPattern.Commands;

namespace CommandPattern.ConcreteCommands
{
    public class RemoveCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            currentItems.Remove(currentItems.Where(x => x.Name == newItem.Name).First());
        }
    }

}