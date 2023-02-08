namespace SOLID.InterfaceSegregationPrinciple;

public class BadHomePrinter : IBadPrinterTasks
{
    public void Print(string printContent)
    {
        Console.WriteLine($"Print done: {printContent}");
    }

    public void Scan(string scanContent)
    {
        Console.WriteLine($"Scan content: {scanContent}");
    }

    public void Fax(string faxContent)
    {
        throw new NotImplementedException();
    }

    public void PrintDuplex(string printDuplexContent)
    {
        throw new NotImplementedException();
    }
}