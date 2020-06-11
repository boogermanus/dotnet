namespace ProxyPattern.Subject
{
    public interface IHero
    {
        string Name { get; }
        string Location { get; }

        void Goto(string location);
        void Fight(IHero hero);
    }
}