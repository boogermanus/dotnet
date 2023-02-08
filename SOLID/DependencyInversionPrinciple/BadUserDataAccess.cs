namespace SOLID.DependencyInversionPrinciple;

public class BadUserDataAccess
{
    // this is basically a repository
    public BadUser GetUser(int id)
    {
        var users = new List<BadUser> { new(0, "boogermanus", false), new(1, "jordan.woodruff", true) };
        return users.First(u => u.Id == id);
    }
}