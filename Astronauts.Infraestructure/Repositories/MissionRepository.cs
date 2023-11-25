using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Astronauts.Infraestructure.Repositories;

public class MissionRepository :BaseRepository<Mission>, IMissionRepository
{
    public MissionRepository(AstronautMediaContext context) : base(context) { }
    public async Task<IEnumerable<Mission>> GetMissionsByAstronaut(int astronautId)
    {
        //I need to fix this
        return await _entities.Where(x => x.Id == astronautId).ToListAsync();
    }
}
