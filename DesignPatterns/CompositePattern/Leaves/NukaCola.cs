using CompositePattern.Components;

namespace CompositePattern.Leaves
{
    public class NukaCola : DisperserDrink
    {
        public NukaCola() : base(170) {}
        public override void Add(DisperserDrink drink)
        {
            throw new System.NotImplementedException();
        }

        public override string Display(int depth)
        {
            return base.ToString();
        }

        public override void Remove(DisperserDrink drink)
        {
            throw new System.NotImplementedException();
        }
    }
}