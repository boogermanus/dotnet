namespace FakeItEasy.Interfaces
{
    public interface IFakeItEasyService
    {
        void IncrementCount();
        void IncrementBy(int count);
        int GetCount();
        int GetCount(string option);
    }
}