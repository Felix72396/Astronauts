using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Infraestructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AstronautMediaContext _context;
    protected readonly DbSet<T> _entities;

    public BaseRepository(AstronautMediaContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public async Task<T> GetById(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task Post(T entity)
    {
        await _entities.AddAsync(entity);
    }
}
