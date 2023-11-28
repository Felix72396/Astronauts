using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Astronauts.Core.Services;

public class MissionService : IMissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaginationOptions _paginationOptions;

    public MissionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    {
        _unitOfWork = unitOfWork;
        _paginationOptions = options.Value;
    }

    public PagedList<Mission> GetMissions(BaseQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

        var missions = _unitOfWork.MissionRepository.GetAll();

        var pagedMissions = PagedList<Mission>.Create(missions, filters.PageNumber, filters.PageSize);
        return pagedMissions;
    }

    public async Task<Mission> GetMission(int id)
    {
        return await _unitOfWork.MissionRepository.GetById(id);
    }

    public async Task PostMission(Mission mission)
    {
        await _unitOfWork.MissionRepository.Post(mission);
        await _unitOfWork.SaveChangesAsync();
    }
}
