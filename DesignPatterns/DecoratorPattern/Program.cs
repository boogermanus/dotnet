using System;
using System.Collections.Generic;
using DecoratorPattern.ConcreteComponent;
using DecoratorPattern.Decarator;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Dish();
        }

        static void Dish()
        {
            FreshSalad ceasarSalad = new FreshSalad(
                new Dictionary<string, string>
                {
                    {"Greens", "Crispy romaine lettuce"},
                    {"Cheese", "Freshly-grated Parmasan cheese"},
                    {"Dressing", "House-made Caesar dressing"}
                }
            );

            Pasta fettuccineAlfredo = new Pasta(
                new Dictionary<string, string>
                {
                    {"Pasta", "Fresh-made daily pasta"},
                    {"Sauce", "Creamy garlic alfredo sauce"}
                }
            );

            Console.WriteLine(ceasarSalad);
            Console.WriteLine(fettuccineAlfredo);

            AvailableDecorator caesarAvailable = new AvailableDecorator(ceasarSalad, 2);
            AvailableDecorator alfredoAvailable = new AvailableDecorator(fettuccineAlfredo, 3);

            caesarAvailable.OrderItem("Superman");
            caesarAvailable.OrderItem("Batman");

            alfredoAvailable.OrderItem("Wonder Women");
            alfredoAvailable.OrderItem("Plastic Man");
            alfredoAvailable.OrderItem("Flash");

            // not enough
            alfredoAvailable.OrderItem("Batman");

            Console.WriteLine(caesarAvailable);
            Console.WriteLine(alfredoAvailable);
        }
    }
}
