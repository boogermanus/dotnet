using System;

using AdapterPattern.Target;
using AdapterPattern.Adaptor;
using AdapterPattern.Constants;
namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Meat();
        }

        static void Meat()
        {
            // non-adapted
            var unknown = new MeatBase(MeatTypes.BEEF);
            unknown.LoadData();

            // adapted
            var beef = new Meat(MeatTypes.BEEF);
            beef.LoadData();

            var turkey = new Meat(MeatTypes.TURKEY);
            turkey.LoadData();

            var veal = new Meat(MeatTypes.VEAL);
            veal.LoadData();

            Console.ReadKey();
        }
    }
}
