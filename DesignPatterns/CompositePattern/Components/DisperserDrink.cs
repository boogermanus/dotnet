namespace CompositePattern.Components
{
    public abstract class DisperserDrink
    {
        public int Calories { get; set; }
        public string Name { get; set; }
        public DisperserDrink(int calories)
        {
            Calories = calories;
        }

        public abstract void Add(DisperserDrink drink);
        public abstract void Remove(DisperserDrink drink);
        public abstract string Display(int depth);

        public override string ToString()
        {
            return $"{GetType().Name} - Calories: {Calories}";
        }
    }
}