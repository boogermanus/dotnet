using System;

namespace TemplateMethodPattern.AbstractClasses
{
    public abstract class Bread
    {
        protected abstract void MixIngredients();

        protected abstract void Bake();

        private void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread!");
        }

        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}