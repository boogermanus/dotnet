using AbstractFactoryPattern.AbstractProduct;

namespace AbstractFactoryPattern.ConcreteProduct
{
    public class BruceWayne : Name
    {
        public override string GetName() => "Bruce Wayne";
    }
}