using Ingredients;
namespace Sandwiches
{
    // This is a Concrete Creator
    public class HamSandwich : Sandwich
    {
        public override string Name => "Ham";

        protected override void AddIngredients()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new Ham());
            Ingredients.Add(new Cheese());
            Ingredients.Add(new Bread());
        }
    }
}