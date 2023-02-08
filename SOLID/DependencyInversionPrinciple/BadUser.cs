namespace SOLID.DependencyInversionPrinciple;

public class BadUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public bool IsLockedOut { get; set; }
    
    public BadUser(int id, string userName, bool isLockedOut)
    {
        Id = id;
        UserName = userName;
        IsLockedOut = isLockedOut;
    }
}