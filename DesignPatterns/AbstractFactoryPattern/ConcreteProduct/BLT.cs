using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.ConcreteProduct
{
    public class BLT : Sandwich
    {
        public override string Name => nameof(BLT);
    }
}