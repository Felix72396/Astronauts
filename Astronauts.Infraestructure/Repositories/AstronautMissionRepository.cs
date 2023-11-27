using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Astronauts.Infraestructure.Repositories;

public class AstronautMissionRepository : IAstronautMissionRepository
{
    private readonly AstronautMediaContext _context;
    protected readonly DbSet<AstronautMission> _entity;

    public AstronautMissionRepository(AstronautMediaContext context)
    {
        _context = context;
        _entity = context.Set<AstronautMission>();
    }

    public async Task<IEnumerable<Mission>> GetMissionsByAstronaut(int astronautId)
    {
        var missions = await _context.AstronautMissions
        .Where(am => am.AstronautId == astronautId)
        .Select(am => am.Mission) // Retrieve Mission entities associated with the astronaut
        .ToListAsync();

        return missions;
    }

    public async Task Post(AstronautMission entity)
    {
        await _entity.AddAsync(entity);
    }
}
