using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface ISecurityRepository : IRepository<Security>
{
    Task<Security> GetLoginByCredentials(UserLogin login);
}