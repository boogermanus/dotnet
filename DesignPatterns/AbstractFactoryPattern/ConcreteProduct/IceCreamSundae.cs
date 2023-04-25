using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.ConcreteProduct
{
    public class IceCreamSundae: Dessert
    {
        public override string Name => nameof(IceCreamSundae);
    }
}