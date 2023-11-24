using Microsoft.EntityFrameworkCore;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;


namespace Astronauts.Infraestructure.Repositories;

public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
{
    public SecurityRepository(AstronautMediaContext context) : base(context) { }

    public async Task<Security> GetLoginByCredentials(UserLogin login)
    {
        return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
    }
}
