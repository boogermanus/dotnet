using System;
using TemplateMethodPattern.AbstractClasses;

namespace TemplateMethodPattern.ConcreteClasses
{
    public class WholeWheat : Bread
    {
        protected override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15-minutes)");
        }

        protected override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
        }
    }
}