namespace SOLID.LiskovSubstitutionPrinciple;

public class BadApple
{
    // okay this is an apple
    public virtual string GetColor()
    {
        return "Red";
    }
}