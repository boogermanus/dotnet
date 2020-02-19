namespace FacadePattern.Models
{
    public class Patron
    {
        private string _name;
        public string Name => _name;

        public Patron(string name)
        {
            _name = name;
        }
    }
}