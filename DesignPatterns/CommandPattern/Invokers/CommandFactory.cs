using CommandPattern.Commands;
using CommandPattern.ConcreteCommands;

namespace CommandPattern.Invokers
{
    public enum CommandTypes { Add, Modify, Remove }
    public class CommandFactory
    {
        //Factory method
        public OrderCommand GetCommand(CommandTypes commandOption)
        {
            switch (commandOption)
            {
                case CommandTypes.Add:
                    return new AddCommand();
                case CommandTypes.Modify:
                    return new ModifyCommand();
                case CommandTypes.Remove:
                    return new RemoveCommand();
                default:
                    return new AddCommand();
            }
        }
    }
}