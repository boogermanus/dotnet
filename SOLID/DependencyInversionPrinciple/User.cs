namespace SOLID.DependencyInversionPrinciple;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public bool IsLockedOut { get; set; }
    
    public User(int id, string userName, bool isLockedOut)
    {
        Id = id;
        UserName = userName;
        IsLockedOut = isLockedOut;
    }
}