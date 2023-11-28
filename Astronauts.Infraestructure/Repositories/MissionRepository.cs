using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Infraestructure.Repositories;

public class MissionRepository : BaseRepository<Mission>, IMissionRepository
{
    public MissionRepository(AstronautMediaContext context) : base(context) { }
}