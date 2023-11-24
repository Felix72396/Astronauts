using Astronauts.Core.CustomEntities;
namespace Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;


using Astronauts.Core.Entities;
public interface IAstronautService
{
    PagedList<Astronaut> GetAll(AstronautQueryFilter filters);
    Task<Astronaut> GetById(int id);
    Task Post(Astronaut austronaut);
}