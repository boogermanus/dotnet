namespace FacadePattern.Models
{
    public class Patron
    {
        private string _name;
        public string Name => _name;

        public int ColdPrepId { get; set; }
        public int HotPrepId { get; set; }
        public int BarPrepId { get; set; }


        public Patron(string name)
        {
            _name = name;
        }
    }
}