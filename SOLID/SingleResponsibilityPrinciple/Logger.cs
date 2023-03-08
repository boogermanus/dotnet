namespace SOLID.SingleResponsibilityPrinciple;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now}: {message}");
    }
    
}