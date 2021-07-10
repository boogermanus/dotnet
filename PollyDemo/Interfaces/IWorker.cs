namespace PollyDemo.Interfaces
{
    public interface IWorker
    {
        public void DoWork();
        public void DoWorkWithParams(string[] args);
    }
}