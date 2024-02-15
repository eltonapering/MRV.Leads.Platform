namespace MRV.Leads.Platform.Application.Interfaces;

public interface IMessageConsumer
{
    void StartConsuming(CancellationToken stoppingToken);
}
