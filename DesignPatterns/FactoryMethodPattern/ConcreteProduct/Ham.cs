using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Ham : Ingredient
    {
        public override string Name => nameof(Ham);
    }
}