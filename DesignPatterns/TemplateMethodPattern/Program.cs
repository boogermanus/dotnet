using System;
using TemplateMethodPattern.ConcreteClasses;

namespace TemplateMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeBread();
        }

        static void MakeBread()
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
            Console.ReadKey();

        }
    }
}
