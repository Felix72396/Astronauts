using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astronauts.Core.Services;

public class AstronautSocialMediaService : IAstronautSocialMediaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaginationOptions _paginationOptions;

    public AstronautSocialMediaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    {
        _unitOfWork = unitOfWork;
        _paginationOptions = options.Value;
    }

    public PagedList<SocialMedia> GetSocialMediaByAstronaut(BaseQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

        var socialMediaByAstronaut = _unitOfWork.AstronautSocialMediaRepository.GetSocialMediaByAstronaut(filters.AstronautId.Value);
        var socialMedia = socialMediaByAstronaut.Result; // Assuming GetSocialMediasByAstronaut returns a Task<IEnumerable<SocialMedia>>

        var pagedMissions = PagedList<SocialMedia>.Create(socialMedia, filters.PageNumber, filters.PageSize);
        return pagedMissions;
    }

    public async Task PostAstronautSocialMedia(AstronautSocialMedia astronautSocialMedia)
    {
        await _unitOfWork.AstronautSocialMediaRepository.Post(astronautSocialMedia);
        await _unitOfWork.SaveChangesAsync();
    }
}
