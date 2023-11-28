﻿using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Astronauts.Core.Services;

public class SocialMediaService : ISocialMediaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaginationOptions _paginationOptions;

    public SocialMediaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    {
        _unitOfWork = unitOfWork;
        _paginationOptions = options.Value;
    }

    public PagedList<SocialMedia> GetSocialMedia(BaseQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

        var socialMedia = _unitOfWork.SocialMediaRepository.GetAll();

        var pagedMissions = PagedList<SocialMedia>.Create(socialMedia, filters.PageNumber, filters.PageSize);
        return pagedMissions;
    }

    public async Task<SocialMedia> GetSocialMedia(int id)
    {
        return await _unitOfWork.SocialMediaRepository.GetById(id);
    }

    public async Task PostSocialMedia(SocialMedia socialMedia)
    {
        await _unitOfWork.SocialMediaRepository.Post(socialMedia);
        await _unitOfWork.SaveChangesAsync();
    }
}
