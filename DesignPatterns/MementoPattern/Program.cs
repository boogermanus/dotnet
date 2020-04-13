using System;
using MementoPattern.Caretaker;
using MementoPattern.Originator;

namespace MementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           // Food();
           Hero();
        }

        static void Food()
        {
            var supplier = new FoodSupplier
            {
                Name = "Jordan Woodruff",
                Phone = "8068675309",
            };

            SupplierMemory memory = new SupplierMemory(supplier.SaveMemento());

            supplier.Address = "132 Sesame St.";

            supplier.RestoreMemento(memory.FoodSupplierMemento);

            Console.ReadKey();
        }

        static void Hero()
        {
            var hero = new Hero
            {
                Name = "Batman",
                Location = "Gotham City",
                Mission = "Catch the Joker"
            };

            Console.WriteLine(hero);

            HeroMemory memory = new HeroMemory(hero.SaveHero());

            hero.Mission = "Investigate a Robbery";

            Console.WriteLine(hero);

            hero = hero.RestoreHero(memory.HeroMemento);

            Console.WriteLine(hero);
        }
    }
}
