using AdapterPattern.Constants;

namespace AdapterPattern.Adaptee
{
    public class HeroDatabase
    {
        public string GetHeroName(string hero)
        {
            switch (hero)
            {
                case Heroes.Superman:
                    return "Clark Kent";
                case Heroes.Batman:
                    return "Bruce Wayne";
                case Heroes.WonderWomen:
                    return "Diana Prince";
                default:
                    return "Unknown";
            }
        }

        public string GetHeroCity(string hero)
        {
            switch (hero)
            {
                case Heroes.Superman:
                    return "Metroplis";
                case Heroes.Batman:
                    return "Gotham City";
                case Heroes.WonderWomen:
                    return "Themyscira";
                default:
                    return "Unknown";
            }
        }

        public int GetHeroAge(string hero)
        {
            switch (hero)
            {
                case Heroes.Superman:
                    return 42;
                case Heroes.Batman:
                    return 39;
                case Heroes.WonderWomen:
                    return 34;
                default:
                    return 0;
            }
        }

    }
}