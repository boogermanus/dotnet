using System.Collections.Generic;

namespace CommandPattern.Commands
{
    public abstract class OrderCommand
    {
        public abstract void Execute(List<MenuItem> order, MenuItem newItem);
    }
}