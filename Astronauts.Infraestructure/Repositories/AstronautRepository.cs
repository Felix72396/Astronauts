
using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Infraestructure.Repositories;
public class AstronautRepository : BaseRepository<Astronaut>, IAstronautRepository
{
    public AstronautRepository(AstronautMediaContext context) : base(context) { }

   

    //Task<IEnumerable<Astronaut>> IAstronautRepository.GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //public async Task<IEnumerable<Austronaut>> GetPostsByUser(int userId)
    //{
    //    return await _entities.Where(x => x.UserId == userId).ToListAsync();
    //}
}
