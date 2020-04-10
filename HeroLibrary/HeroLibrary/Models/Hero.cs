using System.Collections.Generic;

namespace HeroLibrary.Models
{
    public abstract class Hero : BaseEntity
    {
        public string Alias { get; set; }
        public string City { get; set; }
        public List<Power> Powers { get; set; } = new List<Power>();

        public Hero()
        {
            ImagineHero();
        }

        public abstract void ImagineHero();

    }
}