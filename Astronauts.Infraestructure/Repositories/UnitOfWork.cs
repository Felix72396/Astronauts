using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Infraestructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AstronautMediaContext _context;
    private readonly IAstronautRepository _astronautRepository;
    private readonly ISecurityRepository _securityRepository;

    public UnitOfWork(AstronautMediaContext context)
    {
        _context = context;
    }

    public IAstronautRepository AstronautRepository => _astronautRepository ?? new AstronautRepository(_context);

    public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

    public void Dispose()
    {
        if(_context != null)
            _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
