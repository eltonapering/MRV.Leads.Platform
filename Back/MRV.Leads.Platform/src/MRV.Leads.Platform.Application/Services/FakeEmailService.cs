using MRV.Leads.Platform.Application.Interfaces;

namespace MRV.Leads.Platform.Application.Services;

public class FakeEmailService : IEmailService
{
    private readonly string _fakeEmailFilePath;

    public FakeEmailService(string fakeEmailFilePath)
    {
        _fakeEmailFilePath = fakeEmailFilePath;
    }

    public Task SendEmailAsync(string to, string subject, string body)
    {   
        var emailContent = $"To: {to}\nSubject: {subject}\nBody:\n{body}\n" + "\n";
        File.AppendAllText(_fakeEmailFilePath, emailContent);

        Console.WriteLine($"Fake email sent to {to} with subject '{subject}'.");

        return Task.CompletedTask;
    }
}
