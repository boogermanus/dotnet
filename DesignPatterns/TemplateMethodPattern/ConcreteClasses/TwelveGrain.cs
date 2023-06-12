using System;
using TemplateMethodPattern.AbstractClasses;

namespace TemplateMethodPattern.ConcreteClasses
{
    public class TwelveGrain : Bread
    {
        protected override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25-minutes)");
        }

        protected override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }
    }
}