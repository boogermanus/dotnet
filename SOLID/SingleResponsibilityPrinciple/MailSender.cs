namespace SOLID.SingleResponsibilityPrinciple;

public class MailSender
{
    private ILogger _log;

    public MailSender()
    {
        _log = new Logger();
    }

    public void Send(MailMessage message)
    {
        _log.Log(message.ToString());
    }
}