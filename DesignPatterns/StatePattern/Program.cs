using System;
using StatePattern.AbstractContext;
using StatePattern.Context;
using StatePattern.State;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Steak();
            Fight();
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

        static void Fight()
        {
            Hero superman = new Superman();
            Hero darkseid = new Darkseid();

            superman.Attack(darkseid);
            darkseid.Attack(superman);
            superman.Attack(darkseid);
            darkseid.Attack(superman);
            darkseid.Attack(superman);
            superman.Heal();
            superman.Heal();
            superman.Attack(darkseid);
            superman.Attack(darkseid);
            darkseid.Heal();
        }
    }
}
