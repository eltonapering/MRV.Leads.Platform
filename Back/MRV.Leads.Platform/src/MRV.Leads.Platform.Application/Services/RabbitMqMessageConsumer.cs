using MRV.Leads.Platform.Application.Events.Messages;
using MRV.Leads.Platform.Application.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MRV.Leads.Platform.Application.Services;

public class RabbitMqMessageConsumer : IMessageConsumer
{
    private readonly string _hostname;
    private readonly string _queueName;
    private readonly IEmailService _emailService;

    public RabbitMqMessageConsumer(string hostname, string queueName, IEmailService emailService)
    {
        _hostname = hostname;
        _queueName = queueName;
        _emailService = emailService;
    }

    public void StartConsuming(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = _hostname };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {            
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            
            var message = JsonConvert.DeserializeObject<IntentAcceptedMessage>(json);
            
            if (message != null)
            {
                await _emailService.SendEmailAsync(message.Email, message.Subject, message.Body);
            }
        };
        
        channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
    }
}