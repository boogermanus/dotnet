namespace CompositePattern.Components
{
    public abstract class DispenserDrink
    {
        public int Calories { get; set; }
        public string Name { get; set; }
        public DispenserDrink(int calories)
        {
            Calories = calories;
        }

        public abstract void Add(DispenserDrink drink);
        public abstract void Remove(DispenserDrink drink);
        public abstract string Display(int depth);

        public override string ToString()
        {
            return $"{GetType().Name} - {(Calories != 0 ? $"Calories {Calories}" : string.Empty)}";
        }
    }
}