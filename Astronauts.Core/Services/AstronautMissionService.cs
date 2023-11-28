using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Astronauts.Core.Services;

public class AstronautMissionService : IAstronautMissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaginationOptions _paginationOptions;

    public AstronautMissionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    {
        _unitOfWork = unitOfWork;
        _paginationOptions = options.Value;
    }

    public PagedList<Mission> GetMissionsByAstronaut(BaseQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

        var missionsByAstronaut = _unitOfWork.AstronautMissionRepository.GetMissionsByAstronaut(filters.AstronautId.Value);
        var missions = missionsByAstronaut.Result; // Assuming GetMissionsByAstronaut returns a Task<IEnumerable<Mission>>

        var pagedMissions = PagedList<Mission>.Create(missions, filters.PageNumber, filters.PageSize);
        return pagedMissions;
    }

    public async Task PostAstronautMission(AstronautMission astronautMission)
    {
        await _unitOfWork.AstronautMissionRepository.Post(astronautMission);
        await _unitOfWork.SaveChangesAsync();
    }
}
