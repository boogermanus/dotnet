using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Mustard : Ingredient
    {
        public override string Name => nameof(Mustard);
    }
}