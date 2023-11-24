using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Astronauts.Core.Services;
public class AstronautService : IAstronautService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaginationOptions _paginationOptions;

    public AstronautService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    {
        _unitOfWork = unitOfWork;
        _paginationOptions = options.Value;
    }

    public PagedList<Astronaut> GetAll(AstronautQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageNumber;

        var austronauts = _unitOfWork.AstronautRepository.GetAll();

        if (filters.Nacionality != null)
            austronauts = austronauts.Where(x => x.Nationality == filters.Nacionality);

        if (filters.Status != null)
            austronauts = austronauts.Where(x => x.Status == filters.Status);

        var pagedAustronauts = PagedList<Astronaut>.Create(austronauts, filters.PageNumber, filters.PageSize);
        return pagedAustronauts;
    }

    public async Task<Astronaut> GetById(int id)
    {
        return await _unitOfWork.AstronautRepository.GetById(id);
    }

    public async Task Post(Astronaut austronaut)
    {
        await _unitOfWork.AstronautRepository.Post(austronaut);
        await _unitOfWork.SaveChangesAsync();
    }
}
