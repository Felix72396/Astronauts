using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;
public interface IMissionRepository : IRepository<Mission>
{
    Task<IEnumerable<Mission>> GetMissionsByAstronaut(int astronautId);
}
