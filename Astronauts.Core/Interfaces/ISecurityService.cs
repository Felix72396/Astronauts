using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface ISecurityService
{
    Task<Security> GetLoginByCredentials(UserLogin userLogin);
    Task RegisterUser(Security security);
}