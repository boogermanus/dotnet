namespace FakeItEasyDemo.Interfaces
{
    public interface IDependentService
    {
        public decimal GetTotalAbv();
        public decimal GetBeerAbv(int id);
    }
}