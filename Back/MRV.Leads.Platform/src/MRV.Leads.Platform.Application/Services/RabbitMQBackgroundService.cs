using Microsoft.Extensions.Hosting;
using MRV.Leads.Platform.Application.Interfaces;

namespace MRV.Leads.Platform.Application.Services;

public class RabbitMQBackgroundService : BackgroundService
{
    private readonly IMessageConsumer _messageConsumer;

    public RabbitMQBackgroundService(IMessageConsumer messageConsumer)
    {
        _messageConsumer = messageConsumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {   
                _messageConsumer.StartConsuming(stoppingToken);
                
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            catch (OperationCanceledException)
            {   
                break;
            }
        }
    }
}