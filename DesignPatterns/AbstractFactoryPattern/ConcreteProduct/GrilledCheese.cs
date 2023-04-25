using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.ConcreteProduct
{
    public class GrilledCheese: Sandwich
    {
        public override string Name => nameof(GrilledCheese);
    }
}