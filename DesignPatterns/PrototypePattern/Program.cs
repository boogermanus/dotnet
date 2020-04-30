using System;
using PrototypePattern.Client;
using PrototypePattern.ConcretePrototype;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Sandwhiches();
        }

        static void Sandwhiches()
        {
            var sandwichMenu = new SandwichMenu();
            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Vegetarian"].Clone() as Sandwich;

            try
            {
                var noSandwich = sandwichMenu["TEST"].Clone() as Sandwich;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();

        }
    }
}
