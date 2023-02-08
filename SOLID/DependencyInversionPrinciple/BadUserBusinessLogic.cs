namespace SOLID.DependencyInversionPrinciple;

public class BadUserBusinessLogic
{
    private BadUserDataAccess _badUserAccess;

    public BadUserBusinessLogic()
    {
        _badUserAccess = BadUserDataAccessFactory.GetBadUserAccess();
    }

    public User GetUser(int id)
    {
        return _badUserAccess.GetUser(id);
    }

    public User FindUser(int id)
    {
        // does not compile
        // return _badUserAccess.FindUser(id)
        return new User(0, "jordan.woodruff", false);
    }
}