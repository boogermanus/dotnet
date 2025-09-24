namespace MoqItDemo.Interfaces
{
    public interface IDependentService
    {
        public Task<decimal> GetTotalAbv();
        public Task<decimal> GetBeerAbv(int id);
    }
}