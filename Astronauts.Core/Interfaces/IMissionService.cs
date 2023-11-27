using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.QueryFilters;

namespace Astronauts.Core.Interfaces;

public interface IMissionService
{
    PagedList<Mission> GetMissions(MissionQueryFilter filters);
    Task<Mission> GetMission(int id);
    Task PostMission(Mission mission);
}
