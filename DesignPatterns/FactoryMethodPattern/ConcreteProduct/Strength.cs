using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Strength : PowerBase
    {
        public override string Power => nameof(Strength);
    }
}