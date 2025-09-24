namespace LinqExamples
{
    public interface IHero
    {
        public string Name { get; set; }
        public decimal PowerLevel { get; set; }
        public string[] Powers { get; set; }
        public bool IsVillain { get; set; }
        public string Team { get; set; }
    }
}