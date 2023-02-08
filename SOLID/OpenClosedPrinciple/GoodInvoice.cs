namespace SOLID.OpenClosedPrinciple;

public class GoodInvoice
{
    protected decimal _amount;

    protected GoodInvoice(decimal amount)
    {
        _amount = amount;
    }

    public virtual decimal GetInvoiceDiscount()
    {
        return _amount;
    }
}