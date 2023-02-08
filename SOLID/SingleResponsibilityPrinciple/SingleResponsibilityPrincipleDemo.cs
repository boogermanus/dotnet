namespace SOLID.SingleResponsibilityPrinciple;

public class SingleResponsibilityPrincipleDemo : IDemo
{
    public void Run()
    {
        var badInvoiceManager = new BadInvoiceManager();
        badInvoiceManager.AddInvoice(12);
        badInvoiceManager.RemoveInvoice(0);

        var goodInvoiceManager = new GoodInvoiceManager();
        goodInvoiceManager.AddInvoice(12);
        goodInvoiceManager.RemoveInvoice(0);
    }
}