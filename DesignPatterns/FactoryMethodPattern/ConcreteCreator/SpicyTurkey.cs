
using FactoryMethodPattern.ConcreteProduct;
using FactoryMethodPattern.Creator;

namespace FactoryMethodPattern.ConcreteCreator
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