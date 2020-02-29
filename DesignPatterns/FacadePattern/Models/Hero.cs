namespace FacadePattern.Models
{
    public class Hero
    {
        int Id { get; set; }
        string Name { get; set; }

        public Hero(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}