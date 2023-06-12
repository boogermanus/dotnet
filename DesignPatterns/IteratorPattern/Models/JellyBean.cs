namespace IteratorPattern.Models
{
    public class JellyBean
    {
        public string Flavor { get; }

        public JellyBean(string flavor)
        {
            Flavor = flavor;
        }

        public override string ToString()
        {
            return Flavor;
        }
    }
}