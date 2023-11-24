namespace Astronauts.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;



public class AstronautRepository : BaseRepository<Astronaut>, IAstronautRepository
{
    public AstronautRepository(AstronautMediaContext context) : base(context) { }

    //public async Task<IEnumerable<Austronaut>> GetPostsByUser(int userId)
    //{
    //    return await _entities.Where(x => x.UserId == userId).ToListAsync();
    //}
}
