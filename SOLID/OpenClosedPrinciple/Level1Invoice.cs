namespace SOLID.OpenClosedPrinciple;

public class Level1Invoice : GoodInvoice
{
    public Level1Invoice(decimal amount) : base(amount)
    {
        
    }

    public override decimal GetInvoiceDiscount()
    {
        return _amount - _amount * 0.50m;
    }
}