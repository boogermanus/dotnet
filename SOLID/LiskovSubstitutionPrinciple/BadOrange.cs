namespace SOLID.LiskovSubstitutionPrinciple;

public class BadOrange : BadApple
{
    public override string GetColor()
    {
        return "Orange";
    }
}