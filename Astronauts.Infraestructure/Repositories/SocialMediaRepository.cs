using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Astronauts.Infraestructure.Repositories;

public class SocialMediaRepository : ISocialMediaRepository
{
    private readonly AstronautMediaContext _context;
    protected readonly DbSet<SocialMedia> _entity;

    public SocialMediaRepository(AstronautMediaContext context)
    {
        _context = context;
        _entity = context.Set<SocialMedia>();
    }

    public async Task<IEnumerable<SocialMedia>> GetSocialMediaByAstronaut(int id)
    {
        var socialMedia = await _context.SocialMedia
        .Where(sm => sm.AstronautId == id)
        .ToListAsync();

        return socialMedia;
    }

    public async Task<SocialMedia> GetById(int id)
    {
        return await _entity.FindAsync(id);
    }

    public async Task Post(SocialMedia entity)
    {
        await _entity.AddAsync(entity);
    }

    public void Update(SocialMedia entity)
    {
        _entity.Update(entity);
    }

    public async Task Delete(int id)
    {
        SocialMedia entity = await GetById(id);
        _entity.Remove(entity);
    }
}
