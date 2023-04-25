using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Regeneration : PowerBase
    {
        public override string Power => nameof(Regeneration);
    }
}