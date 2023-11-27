using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface IAstronautRepository : IRepository<Astronaut>
{
    //Task<Mission> GetMissionsByAstronaut();
}

