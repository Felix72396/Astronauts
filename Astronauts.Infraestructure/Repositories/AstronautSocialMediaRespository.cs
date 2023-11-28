using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Astronauts.Core.DTOs;
namespace Astronauts.Infraestructure.Repositories;

public class AstronautSocialMediaRespository : IAstronautSocialMediaRepository
{
    private readonly AstronautMediaContext _context;
    protected readonly DbSet<AstronautSocialMedia> _entity;

    public AstronautSocialMediaRespository(AstronautMediaContext context)
    {
        _context = context;
        _entity = context.Set<AstronautSocialMedia>();
    }

    public async Task<IEnumerable<CustomSocialMediaDto>> GetSocialMediaByAstronaut(int astronautId)
    {
        var socialMedia = await _context.AstronautSocialMedia
        .Where(asm => asm.AstronautId == astronautId)
        .Include(asm => asm.SocialMedia) // Include the SocialMedia entity
        .Select(asm => new CustomSocialMediaDto
        {
            SocialMediaId = asm.SocialMediaId,
            Description = asm.SocialMedia.Description,
            Link = asm.Link
        })
        .ToListAsync();

        return socialMedia;
    }

    public async Task Post(AstronautSocialMedia entity)
    {
        await _entity.AddAsync(entity);
    }
}