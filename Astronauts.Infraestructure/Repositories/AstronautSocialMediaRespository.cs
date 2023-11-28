using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Astronauts.Infraestructure.Repositories;

public class AstronautSocialMediaRespository : IAstronautSocialMediaRepository
{
    private readonly AstronautMediaContext _context;
    protected readonly DbSet<AstronautSocialMedia> _entity;

    public AstronautSocialMediaRepository(AstronautMediaContext context)
    {
        _context = context;
        _entity = context.Set<AstronautSocialMedia>();
    }

    public async Task<IEnumerable<SocialMedia>> GetSocialMediaByAstronaut(int astronautId)
    {
        var socialMedia = await _context.AstronautSocialMedia
        .Where(am => am.AstronautId == astronautId)
        .Select(am => am.SocialMedia) // Retrieve SocialMedia entities associated with the astronaut
        .ToListAsync();

        return socialMedia;
    }

    public async Task Post(AstronautSocialMedia entity)
    {
        await _entity.AddAsync(entity);
    }
}