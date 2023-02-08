namespace SOLID.DependencyInversionPrinciple;

public class GoodUserDataAccess : IGoodUserDataAccess
{
    public User GetUser(int id)
    {
        var users = new List<User> { new(0, "boogermanus", false), new(1, "jordan.woodruff", true) };
        return users.First(u => u.Id == id);
    }

    public User FindUser(int id)
    {
        // no implementation
        throw new NotImplementedException();
    }
}