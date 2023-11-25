using Astronauts.Core.CustomEntities;
using Astronauts.Core.QueryFilters;

namespace Astronauts.Core.Interfaces;

using Astronauts.Core.Entities;
public interface IAstronautService
{
    PagedList<Astronaut> GetAstronauts(AstronautQueryFilter filters);
    Task<Astronaut> GetAstronaut(int id);
    Task PostAstronaut(Astronaut austronaut);
}