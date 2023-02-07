namespace SOLID.SingleResponsibilityPrinciple;

public class BadInvoiceManager
{
    private List<Invoice> Invoices { get; set; }
    private int _id;

    public BadInvoiceManager()
    {
        Invoices = new List<Invoice>();
    }

    public void AddInvoice(decimal amount)
    {
        try
        {
            Invoices.Add(new Invoice(_id++, amount));
            SendInvoiceEmail(new MailMessage("to", "from", "invoice", "body"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void RemoveInvoice(int id)
    {
        try
        {
            var target = Invoices.First(i => i.Id == id);
            Invoices.Remove(target);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void SendInvoiceEmail(MailMessage message)
    {
        try
        {
            message.Send();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}