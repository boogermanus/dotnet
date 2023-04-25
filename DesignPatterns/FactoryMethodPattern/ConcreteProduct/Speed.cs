using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Speed : PowerBase
    {
        public override string Power => nameof(Speed);
    }
}