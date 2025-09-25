namespace SOLID.LiskovSubstitutionPrinciple;

public class Orange : Fruit
{
    // this is an orange, but also a fruit.
    public override string GetColor()
    {
        return "Orange";
    }
}