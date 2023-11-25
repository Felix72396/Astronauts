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

    public PagedList<Astronaut> GetAstronauts(AstronautQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageNumber;

        var astronauts = _unitOfWork.AstronautRepository.GetAll();

        if (filters.AstronautId != null)
            astronauts = astronauts.Where(x => x.Id == filters.AstronautId);

        if (filters.Nationality != null)
            astronauts = astronauts.Where(x => x.Nationality == filters.Nationality);

        if (filters.Status != null)
            astronauts = astronauts.Where(x => x.Status == filters.Status);

        var pagedAstronauts = PagedList<Astronaut>.Create(astronauts, filters.PageNumber, filters.PageSize);
        return pagedAstronauts;
    }

    public async Task<Astronaut> GetAstronaut(int id)
    {
        return await _unitOfWork.AstronautRepository.GetById(id);
    }

    public async Task PostAstronaut(Astronaut austronaut)
    {
        await _unitOfWork.AstronautRepository.Post(austronaut);
        await _unitOfWork.SaveChangesAsync();
    }
}
