using SOLID.SingleResponsibilityPrinciple;

namespace SOLID.OpenClosedPrinciple;

public class BadInvoice
{
    private decimal _amount;
    private InvoiceType _type;

    public BadInvoice(decimal amount, InvoiceType type)
    {
        _amount = amount;
        _type = type;
    }

    public decimal GetInvoiceDiscount()
    {
        switch (_type)
        {
            case InvoiceType.Level1:
                return _amount - _amount * 0.50m;
            case InvoiceType.Level2:
                return _amount - _amount * 0.25m;
        }

        return decimal.Zero;
    }
}