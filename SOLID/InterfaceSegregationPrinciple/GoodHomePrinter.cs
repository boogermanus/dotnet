namespace SOLID.InterfaceSegregationPrinciple;

public class GoodHomePrinter : IPrinterTasks
{
    public void Print(string printContent)
    {
        Console.WriteLine($"Print done: {printContent}");
    }

    public void Scan(string scanContent)
    {
        Console.WriteLine($"Scan content: {scanContent}");
    }
}