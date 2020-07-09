using System;
using System.Collections.Generic;
using System.Text;
using CompositePattern.Components;

namespace CompositePattern.Composits
{
    public class Beer : DispenserDrink
    {
        private List<DispenserDrink> _flavors = new List<DispenserDrink>();
        
        public Beer() : base(0) {}

        public override void Add(DispenserDrink drink)
        {
            _flavors.Add(drink);
        }

        public override string Display(int depth)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{new String('-',depth)}{base.ToString()}");

            _flavors.ForEach(f => builder.AppendLine(f.Display(++depth)));

            return builder.ToString();
        }

        public override void Remove(DispenserDrink drink)
        {
            _flavors.Remove(drink);
        }
    }
}