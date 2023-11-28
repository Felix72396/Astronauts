using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.QueryFilters;

namespace Astronauts.Core.Interfaces;

public interface IAstronautMissionService
{
    PagedList<Mission> GetMissionsByAstronaut(BaseQueryFilter filters);
    Task PostAstronautMission(AstronautMission astronautMission);
}
