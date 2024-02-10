namespace MRV.Leads.Platform.Application.Events.Messages;

public class IntentAcceptedMessage
{
    public string IntentId { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}