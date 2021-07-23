namespace PollyDemo.Interfaces
{
    public interface IWorker
    {
        public void DoWork();
        public void DoWorkWithParams(params string[] args);
        public int DoWorkWithResult();
    }
}