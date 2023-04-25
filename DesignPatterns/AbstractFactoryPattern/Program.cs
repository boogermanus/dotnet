using System;
using AbstractFactoryPattern.AbstractFactory;
using AbstractFactoryPattern.ConcreteFactory;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            HeroFactoryDemo();
            CuisineFactoryDemo();
        }

        private static void HeroFactoryDemo()
        {
            var batman = new BatmanFactory();

            Console.WriteLine(batman);
        }
        private static void CuisineFactoryDemo()
        {
            Console.WriteLine("Who are you? (A)dult or (C)hild?");
            char input = Console.ReadKey().KeyChar;
            RecipeFactory factory;
            switch (input)
            {
                case 'A':
                    factory = new AdultCuisineFactory();
                    break;
                case 'C':
                    factory = new KidCuisineFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }
            var sandwich = factory.CreateSandwich();
            var dessert = factory.CreateDessert();
            Console.WriteLine("\nSandwich: " + sandwich.Name);
            Console.WriteLine("Dessert: " + dessert.Name);
            Console.ReadKey();

        }
    }
}
