using RabbitMQ.Client;

namespace MRV.Leads.Platform.Application.Bootstrap;

public class RabbitMqInitializer
{
    private readonly string _hostname;
    private readonly string _queueName;

    public RabbitMqInitializer(string hostname, string queueName)
    {
        _hostname = hostname;
        _queueName = queueName;
    }

    public void Initialize()
    {
        var factory = new ConnectionFactory() { HostName = _hostname };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }
    }
}