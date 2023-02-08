namespace SOLID.InterfaceSegregationPrinciple;

public class InterfaceSegregationPrincipleDemo : IDemo
{
    public void Run()
    {
        var badOfficerPrinter = new BadOfficePrinter();
        badOfficerPrinter.Print("test");
        badOfficerPrinter.Scan("test");
        badOfficerPrinter.Fax("test");
        badOfficerPrinter.PrintDuplex("test");

        var badHomePrinter = new BadHomePrinter();
        badHomePrinter.Print("test");
        badHomePrinter.Scan("test");
        // will throw
        try
        {
            badHomePrinter.Fax("test");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            badHomePrinter.PrintDuplex("test");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        var goodOfficePrinter = new GoodOfficePrinter();
        goodOfficePrinter.Print("test");
        goodOfficePrinter.Scan("test");
        goodOfficePrinter.Fax("test");
        goodOfficePrinter.PrintDuplex("test");

        var goodHomePrinter = new GoodHomePrinter();
        goodHomePrinter.Print("test");
        goodHomePrinter.Scan("test");
        // will not compile
        // goodHomePrinter.Fax("test");
        // goodHomePrinter.PrintDuplex("test");
    }
}