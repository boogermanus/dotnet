using FactoryMethodPattern.Product;

namespace FactoryMethodPattern.ConcreteProduct
{
    public class Invulnerable : PowerBase
    {
        public override string Power => nameof(Invulnerable);
    }
}