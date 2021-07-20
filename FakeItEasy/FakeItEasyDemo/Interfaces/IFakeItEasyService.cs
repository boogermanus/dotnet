namespace FakeItEasyDemo.Interfaces
{
    public interface IFakeItEasyService
    {
        void IncrementCount();
        void IncrementCountBy(int count);
        int GetCount();
        int GetCount(string option);
    }
}