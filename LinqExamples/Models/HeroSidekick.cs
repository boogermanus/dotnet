namespace LinqExamples.Models
{
    public class HeroSidekick : BaseCharacter, IHero
    {
        public string Partner { get; set; }
        public int ClassificationId { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}