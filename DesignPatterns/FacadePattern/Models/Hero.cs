namespace FacadePattern.Models
{
    public class Hero
    {
        private int Id { get; set; }
        public string Name { get; set; }

        public Hero(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}