using CompositePattern.Components;

namespace CompositePattern.Leaves
{
    public class ButterBeer : DisperserDrink
    {
        public ButterBeer() : base(125) {}
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