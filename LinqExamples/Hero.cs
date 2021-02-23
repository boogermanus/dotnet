namespace LinqExamples
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public decimal PowerLevel { get; set; }
        public string[] Powers { get; set; }
        public bool IsVillain { get; set; }
        public string Team { get; set; }

        public Hero()
        {
            Name = string.Empty;
        }
        public override string ToString()
        {
            return $"Hero: {Name} - {PowerLevel}";
        }
    }
}