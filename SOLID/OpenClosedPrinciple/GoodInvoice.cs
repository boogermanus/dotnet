namespace SOLID.OpenClosedPrinciple;

public class GoodInvoice
{
    protected decimal _amount;

    protected GoodInvoice(decimal amount)
    {
        _amount = amount;
    }

    // virtual method can be overriden on inherited classes.
    public virtual decimal GetInvoiceDiscount()
    {
        return _amount;
    }
}