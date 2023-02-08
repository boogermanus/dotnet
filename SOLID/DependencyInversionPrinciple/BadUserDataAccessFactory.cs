namespace SOLID.DependencyInversionPrinciple;

public class BadUserDataAccessFactory
{
    public static BadUserDataAccess GetBadUserAccess()
    {
        return new BadUserDataAccess();
    }
}