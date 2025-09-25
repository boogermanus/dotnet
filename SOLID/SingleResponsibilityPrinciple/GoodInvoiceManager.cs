namespace SOLID.SingleResponsibilityPrinciple;

public class GoodInvoiceManager
{
    private List<Invoice> Invoices { get; set; }
    private int _id;
    private ILogger _log;
    private MailSender _mailSender;
    
    // sends email and logs by other services, good!
    // better yet, inject them!
    public GoodInvoiceManager()
    {
        Invoices = new List<Invoice>();
        _log = new Logger();
        _mailSender = new MailSender();
    }

    public void AddInvoice(decimal amount)
    {
        try
        {
            _log.Log("Adding invoice");
            Invoices.Add(new Invoice(_id++, amount));
            _mailSender.Send(new MailMessage("to", "from", "invoice", "body"));
        }
        catch (Exception e)
        {
            _log.Log(e.ToString());
        }
    }

    public void RemoveInvoice(int id)
    {
        try
        {
            _log.Log("Removing invoice");
            var target = Invoices.First(i => i.Id == id);
            Invoices.Remove(target);
        }
        catch (Exception e)
        {
            _log.Log(e.ToString());
        }
    }
}