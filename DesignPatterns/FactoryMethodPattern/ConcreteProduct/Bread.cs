using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    // This is a Concrete Product
    public class Bread : Ingredient
    {
        public override string Name => nameof(Bread);
    }
}