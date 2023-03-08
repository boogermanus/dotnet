namespace SOLID.LiskovSubstitutionPrinciple;

public class LiskovSubstitutionPrincipleDemo : IDemo
{
    public void Run()
    {
        var badApple = new BadApple();
        Console.WriteLine(badApple.GetColor());
        
        badApple = new BadOrange();
        Console.WriteLine(badApple.GetColor());

        var apple = new Apple();
        Console.WriteLine(apple.GetColor());

        var orange = new Orange();
        Console.WriteLine(orange.GetColor());

        Fruit fruit;
        fruit = apple;
        fruit = orange;
    }
}