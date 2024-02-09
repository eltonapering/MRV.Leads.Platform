using MRV.Leads.Platform.Domain.Entities;

namespace MRV.Leads.Platform.Domain.Interfaces;

public interface IUnitOfWork
{
    Task CompleteAsync();
    IRepository<Intent> Intents { get; }
}
