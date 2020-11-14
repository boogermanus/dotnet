namespace HeroLibrary.Models
{
    public class Power : BaseEntity
    {
        public Power(string name, int level)
        {
            Name = name;
            Level = level;
        }
        public int Level { get; set; }
    }
}