namespace ProxyPattern.Subject
{
    public interface IServer
    {
        void TakeOrder(string order);
        string DeliverOrder();
        void ProcessPayment(string payment);
    }
}