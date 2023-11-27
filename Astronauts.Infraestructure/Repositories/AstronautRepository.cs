
using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Infraestructure.Repositories;
public class AstronautRepository : BaseRepository<Astronaut>, IAstronautRepository
{
    public AstronautRepository(AstronautMediaContext context) : base(context) { }
}
