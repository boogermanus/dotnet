using AbstractFactoryPattern.AbstractFactory;
using AbstractFactoryPattern.AbstractProduct;
using AbstractFactoryPattern.ConcreteProduct;

namespace AbstractFactoryPattern.ConcreteFactory
{
    public class BatmanFactory : HeroFactory
    {
        public override Alias GetAlias()
        {
            return new Batman();
        }

        public override Name GetName()
        {
            return new BruceWayne();
        }
    }
}