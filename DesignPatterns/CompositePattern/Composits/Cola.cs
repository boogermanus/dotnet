using System;
using System.Collections.Generic;
using System.Text;
using CompositePattern.Components;

namespace CompositePattern.Composits
{
    public class Cola : DispenserDrink
    {
        private List<DispenserDrink> _flavors = new List<DispenserDrink>();
        
        public Cola() : base(0) {}

        public override void Add(DispenserDrink drink)
        {
            _flavors.Add(drink);
        }

        public override string Display(int depth)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{new String('-',depth)}");

            _flavors.ForEach(f => builder.AppendLine(f.Display(depth)));

            return builder.ToString();
        }

        public override void Remove(DispenserDrink drink)
        {
            _flavors.Remove(drink);
        }
    }
}