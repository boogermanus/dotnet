namespace SOLID.LiskovSubstitutionPrinciple;

public class LiskovSubstitutionPrincipleDemo : IDemo
{
    public void Run()
    {
        // what if you had a list of BadApples, but you wanted BadOranges?
        var badApple = new BadApple();
        Console.WriteLine(badApple.GetColor());
        
        var badOrange = new BadOrange();
        Console.WriteLine(badOrange.GetColor());
        
        var badList = new List<BadApple>{badApple, badOrange};
        // we'll get bad apples, but also bad oranges!
        var badFruits = badList.OfType<BadApple>();
        Console.WriteLine(badFruits.Count());

        // now we can
        var apple = new Apple();
        Console.WriteLine(apple.GetColor());

        var orange = new Orange();
        Console.WriteLine(orange.GetColor());

        Fruit fruit = apple;
        Console.WriteLine(fruit.GetColor());
        
        fruit = orange;
        Console.WriteLine(fruit.GetColor());
        
        // we will only get they type of fruit we ask for.
        var fruitList = new List<Fruit>{apple,orange};
        var myApple = fruitList.OfType<Apple>().First();
        var myOrange = fruitList.OfType<Orange>().First();
        
        Console.WriteLine(myApple.GetColor());
        Console.WriteLine(myOrange.GetColor());
    }
}