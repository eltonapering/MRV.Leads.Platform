using MRV.Leads.Platform.Application.Events.Messages;
using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client;

namespace MRV.Leads.Platform.Application.Events.Publishers;

public class IntentAcceptedPublisher
{
    private readonly RabbitMQ.Client.IModel _channel;
    private readonly Action _cleanup;

    public IntentAcceptedPublisher(RabbitMQ.Client.IModel channel, Action cleanup)
    {
        _channel = channel;
        _cleanup = cleanup;
    }

    public void PublishIntentAccepted(IntentAcceptedMessage message)
    {
        _channel.QueueDeclare(queue: "intent.accepted.queue",
                         durable: false, 
                         exclusive: false, 
                         autoDelete: false, 
                         arguments: null);


        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        _channel.BasicPublish(
            exchange: "",
            routingKey: "intent.accepted.queue",
            basicProperties: null,
            body: body);
    }

    public void Dispose()
    {
        _cleanup?.Invoke();
    }
}
