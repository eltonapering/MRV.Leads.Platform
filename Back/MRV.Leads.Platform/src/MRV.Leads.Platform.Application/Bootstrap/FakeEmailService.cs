using MRV.Leads.Platform.Application.Events.Messages;

namespace MRV.Leads.Platform.Application.Bootstrap;

public class FakeEmailService
{
    public void SendEmail(IntentAcceptedMessage message)
    {
        var emailContent = $"To: {message.Email}\nSubject: {message.Subject}\nBody: {message.Body}";
        File.WriteAllText("fakeEmailOutput.txt", emailContent);
    }
}
