using System;
using CompositePattern.Components;

namespace CompositePattern.Leaves
{
    public class AlamoBeer : DispenserDrink
    {
        public AlamoBeer() : base(156) {}
        public override void Add(DispenserDrink drink)
        {
            throw new System.NotImplementedException();
        }

        public override string Display(int depth)
        {
            return $"{new String('-', depth)}{base.ToString()}";
        }

        public override void Remove(DispenserDrink drink)
        {
            throw new System.NotImplementedException();
        }
    }
}