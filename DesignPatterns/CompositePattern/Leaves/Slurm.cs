using CompositePattern.Components;

namespace CompositePattern.Leaves
{
    public class Slurm : DispenserDrink
    {
        public Slurm() : base(300) {}
        
        public override void Add(DispenserDrink drink)
        {
            throw new System.NotImplementedException();
        }

        public override string Display(int depth)
        {
            return base.ToString();
        }

        public override void Remove(DispenserDrink drink)
        {
            throw new System.NotImplementedException();
        }
    }
}