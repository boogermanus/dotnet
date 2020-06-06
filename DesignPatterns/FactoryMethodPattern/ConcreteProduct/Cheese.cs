using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Cheese : Ingredient
    {
        public override string Name => nameof(Cheese);
    }
}