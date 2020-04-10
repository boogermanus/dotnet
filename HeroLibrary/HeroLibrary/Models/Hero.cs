namespace HeroLibrary.Models
{
    public abstract class Hero : BaseEntity
    {
        public string Alias { get; set; }
        public string City { get; set; }
        
        public Hero()
        {
            ImagineHero();
        }

        public abstract void ImagineHero();

    }
}