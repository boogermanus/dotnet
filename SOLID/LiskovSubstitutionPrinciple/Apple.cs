namespace SOLID.LiskovSubstitutionPrinciple;

public class Apple : Fruit
{
    // this is an apple, but also a fruit.
    public override string GetColor()
    {
        return "Red";
    }
}