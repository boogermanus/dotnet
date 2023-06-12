using System;
using TemplateMethodPattern.AbstractClasses;

namespace TemplateMethodPattern.ConcreteClasses
{
    public class Sourdough : Bread
    {
        protected override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20-minutes)");
        }

        protected override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }
    }
}