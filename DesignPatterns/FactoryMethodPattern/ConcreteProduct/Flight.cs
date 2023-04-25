using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Flight : PowerBase
    {
        public override string Power => nameof(Flight);
    }
}