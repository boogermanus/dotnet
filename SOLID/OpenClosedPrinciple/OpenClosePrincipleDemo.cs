namespace SOLID.OpenClosedPrinciple;

public class OpenClosePrincipleDemo : IDemo
{
    public void Run()
    {
        // per a discussion these aren't great examples.
        // var invoice1 = new BadInvoice(10, InvoiceType.Level1);
        // Console.WriteLine($"Discount amount {invoice1.GetInvoiceDiscount()}");
        //
        // var invoice2 = new BadInvoice(10, InvoiceType.Level2);
        // Console.WriteLine($"Discount amount {invoice2.GetInvoiceDiscount()}");
        //
        // var level1Invoice = new Level1Invoice(10);
        // Console.WriteLine($"Discount amount {level1Invoice.GetInvoiceDiscount()}");
        //
        // var level2Invoice = new Level2Invoice(10);
        // Console.WriteLine($"Discount amount {level2Invoice.GetInvoiceDiscount()}");
    }
}