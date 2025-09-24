namespace LinqExamples.Models
{
    public class Villain : BaseCharacter, IHero
    {
        public string Hero { get; set; }
        
        public override string ToString()
        {
            return $"Villain: {Name} - {PowerLevel}";
        }
    }
}