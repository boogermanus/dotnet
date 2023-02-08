namespace SOLID.OpenClosedPrinciple;

public class Level2Invoice : GoodInvoice
{
    public Level2Invoice(decimal amount) : base(amount)
    {
        
    }

    public override decimal GetInvoiceDiscount()
    {
        return _amount - _amount * 0.25m;
    }
}