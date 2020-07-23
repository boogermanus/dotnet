using System;
using CommandPattern.Invokers;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Food();
        }

        static void Food()
        {
            var patron = new Patron();

            patron.SetCommand(CommandTypes.Add);
            patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            patron.ExecuteCommand();

            patron.SetMenuItem(new MenuItem("Hamburger", 2, 2.59));
            patron.ExecuteCommand();

            patron.SetMenuItem(new MenuItem("Drink", 2, 1.19));
            patron.ExecuteCommand();

            patron.ShowCurrentOrder();

            patron.SetCommand(CommandTypes.Remove);
            patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            patron.ExecuteCommand();

            patron.ShowCurrentOrder();

            patron.SetCommand(CommandTypes.Modify);
            patron.SetMenuItem(new MenuItem("Hamburger", 4, 2.59));
            patron.ExecuteCommand();
            
            patron.ShowCurrentOrder();
            
        }
    }
}
