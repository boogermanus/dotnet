namespace ProxyPattern.Subject
{
    public interface ISever
    {
        void TakeOrder(string order);
        string DeliveryOrder();
        void ProcessPayment(string payment);
    }
}