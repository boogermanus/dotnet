using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Turkey : Ingredient
    {
        public override string Name => nameof(Turkey);
    }
}