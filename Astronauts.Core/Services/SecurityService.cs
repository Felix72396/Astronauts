using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Core.Services;

public class SecurityService : ISecurityService
{
    private readonly IUnitOfWork _unitOfWork;

    public SecurityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
    {
        return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
    }

    public async Task RegisterUser(Security security)
    {
        await _unitOfWork.SecurityRepository.Post(security);
        await _unitOfWork.SaveChangesAsync();
    }
}
