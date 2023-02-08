namespace SOLID.DependencyInversionPrinciple;

public class GoodUserDataAccessFactory
{
    public static IGoodUserDataAccess GetUserDataAccess()
    {
        return new GoodUserDataAccess();
    }
}