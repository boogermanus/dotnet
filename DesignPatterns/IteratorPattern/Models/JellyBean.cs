namespace IteratorPattern.Models
{
    public class JellyBean
    {
        private string _flavor;
        public string Flavor => _flavor;

        public JellyBean(string flavor)
        {
            _flavor = flavor;
        }
    }
}