using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astronauts.Core.Interfaces;

public interface IMissionService
{
    PagedList<Mission> GetMissions(MissionQueryFilter filters);
    Task<Mission> GetMission(int id);
    Task PostMission(Mission austronaut);
}
