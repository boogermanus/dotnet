namespace SOLID.SingleResponsibilityPrinciple;

public class Invoice
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Invoice(int id, decimal amount)
    {
        Id = id;
        Amount = amount;
        Date = DateTime.Now;
    }
}