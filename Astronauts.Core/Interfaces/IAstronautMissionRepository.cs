using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface IAstronautMissionRepository
{
    Task<IEnumerable<Mission>> GetMissionsByAstronaut(int astronautId);
    Task Post(AstronautMission astronautMission);
}
