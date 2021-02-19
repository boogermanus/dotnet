namespace LinqExamples
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public decimal PowerLevel { get; set; }
        public string[] Powers { get; set; }
        public bool IsVillain { get; set; }

        public override string ToString()
        {
            return $"Hero: {Name} - {PowerLevel}";
        }
    }
}