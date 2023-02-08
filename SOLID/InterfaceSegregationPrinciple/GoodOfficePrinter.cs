namespace SOLID.InterfaceSegregationPrinciple;

public class GoodOfficePrinter : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
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
        Console.WriteLine($"Fax content: {faxContent}");
    }

    public void PrintDuplex(string printDuplexContent)
    {
        Console.WriteLine($"Print duplex done: {printDuplexContent}");
    }
}