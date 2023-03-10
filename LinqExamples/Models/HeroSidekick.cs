namespace LinqExamples
{
    public class HeroSidekick : IHero
    {
        public string Name { get; set; }
        public string Partner { get; set; }
        public int ClassificationId { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}