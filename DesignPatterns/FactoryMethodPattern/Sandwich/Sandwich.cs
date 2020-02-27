using System.Collections.Generic;
using Ingredients;
namespace Sandwiches
{
    // This is the Creator class
    public abstract class Sandwich
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();

        public List<Ingredient> Ingredients => _ingredients;
        
        public abstract string Name {get;}

        public Sandwich()
        {
            AddIngredients();
        }

        protected abstract void AddIngredients();
    }
}