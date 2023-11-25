using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.QueryFilters;

namespace Astronauts.Core.Interfaces;

public interface IAstronautService
{
    PagedList<Astronaut> GetAstronauts(AstronautQueryFilter filters);
    Task<Astronaut> GetAstronaut(int id);
    Task PostAstronaut(Astronaut austronaut);
}
