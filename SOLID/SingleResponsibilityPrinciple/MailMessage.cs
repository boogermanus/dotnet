namespace SOLID.SingleResponsibilityPrinciple;

public class MailMessage
{
    private string _to;
    private string _from;
    private string _subject;
    private string _body;

    public MailMessage(string to, string from, string subject, string body)
    {
        _to = to;
        _from = from;
        _subject = subject;
        _body = body;
    }

    public void Send()
    {
        Console.WriteLine($"To: {_to} From: {_from} Subject: {_subject} Body: {_body}");
    }

    public override string ToString()
    {
        return $"To: {_to} From: {_from} Subject: {_subject} Body: {_body}";
    }
}