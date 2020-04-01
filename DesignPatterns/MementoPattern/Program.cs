using System;
using MementoPattern.Caretaker;
using MementoPattern.Originator;

namespace MementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           Food();
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
    }
}
