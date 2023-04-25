namespace SOLID.DependencyInversionPrinciple;

public class GoodUserBusinessLogic
{
    private readonly IGoodUserDataAccess _dataAccess;

    public GoodUserBusinessLogic()
    {
        _dataAccess = GoodUserDataAccessFactory.GetUserDataAccess();
    }

    public User GetUser(int id)
    {
        return _dataAccess.GetUser(id);
    }

    public User FindUser(int id)
    {
        return _dataAccess.FindUser(id);
    }
}