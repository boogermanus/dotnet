using System;
using System.Collections.Generic;
using StrategyPattern.ConcreteStrategy;
using StrategyPattern.Context;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cook();
            Transform();
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

        static void Transform()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var method = new TransformMethod();
            method.SetStrategy(new DoubleTransform());
            method.SetList(list);
            Console.WriteLine(string.Join(", ", method.Transform()));

            method.SetStrategy(new PowerTransform(2));
            method.SetList(list);
            Console.WriteLine(string.Join(", ", method.Transform()));
        }
    }
}
