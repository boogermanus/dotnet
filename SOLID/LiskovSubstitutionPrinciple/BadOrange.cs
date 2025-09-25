namespace SOLID.LiskovSubstitutionPrinciple;

public class BadOrange : BadApple
{
    // bad, this is an apple but it's also an orange?!
    public override string GetColor()
    {
        return "Orange";
    }
}