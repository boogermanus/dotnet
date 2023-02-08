namespace SOLID.LiskovSubstitutionPrinciple;

public class BadApple
{
    public virtual string GetColor()
    {
        return "Red";
    }
}