namespace MoqItDemo.Interfaces
{
    public interface IMoqService
    {
        void IncrementCount();
        void IncrementCountBy(int count);
        int GetCount();
        int GetCount(string option);
    }
}