namespace SOLID.DependencyInversionPrinciple;

public interface IGoodUserDataAccess
{
    // bad user cannot have this.
    User GetUser(int id);
    // I can add a method here and not implement. 
    User FindUser(int id);
}