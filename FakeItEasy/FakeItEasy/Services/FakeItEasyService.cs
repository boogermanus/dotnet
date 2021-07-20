using FakeItEasy.Interfaces;

namespace FakeItEasy.Services
{
    public class FakeItEasyService : IFakeItEasyService
    {
        private int _count = 0;
        
        public void IncrementCount()
        {
            _count++;
        }

        public void IncrementBy(int count)
        {
            _count += count;
        }

        public int GetCount()
        {
            return _count;
        }

        public int GetCount(string option)
        {
            return option.ToLower() == "zero" ? 0 : _count;
        }
    }
}