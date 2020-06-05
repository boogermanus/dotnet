using System;
using StrategyPattern.ConcreteStrategy;
using StrategyPattern.Context;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Cook();
        }

        static void Cook()
        {
            CookingMethod cookMethod = new CookingMethod();
            Console.WriteLine("What food would you like to cook?");
            var food = Console.ReadLine();
            cookMethod.SetFood(food);
            Console.WriteLine("What cooking strategy would you like to use (1-3)?");
            int input = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();

            switch (input)
            {
                case 1:
                    cookMethod.SetCookingStrategy(new Grilling());
                    cookMethod.Cook();
                    break;
                case 2:
                    cookMethod.SetCookingStrategy(new OvenBaking());
                    cookMethod.Cook();
                    break;
                case 3:
                    cookMethod.SetCookingStrategy(new DeepFrying());
                    cookMethod.Cook();
                    break;
                default:
                    Console.WriteLine("Invalid Selection!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
