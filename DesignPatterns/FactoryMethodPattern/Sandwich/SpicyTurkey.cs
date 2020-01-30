using Ingredients;
namespace Sandwiches
{
    public class SpicyTurkey : Sandwich
    {
        public override string Name => "Spicy Turkey";

        protected override void AddIngredients()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new Turkey());
            Ingredients.Add(new GreenChili());
            Ingredients.Add(new Mustard());
            Ingredients.Add(new Bread());
        }
    }
}