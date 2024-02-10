using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Interfaces;
using MRV.Leads.Platform.Infrastructure.Repositories;

namespace MRV.Leads.Platform.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    private IRepository<Intent> _intents;
    public IRepository<Intent> Intents
    {
        get
        {
            if (_intents == null)
            {
                _intents = new Repository<Intent>(_context);
            }
            return _intents;
        }
    }
}