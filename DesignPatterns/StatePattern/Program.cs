using System;
using StatePattern.Context;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Steak();
        }

        static void Steak()
        {
            // Let's cook a steak!
            Steak account = new Steak("T-Bone");
            // Apply temperature changes
            account.AddTemp(120);
            account.AddTemp(15);
            account.AddTemp(15);
            account.RemoveTemp(10); //Yes I know cooking doesn't work this way
            account.RemoveTemp(15);
            account.AddTemp(20);
            account.AddTemp(20);
            account.AddTemp(20);
            Console.ReadKey();

        }
    }
}
