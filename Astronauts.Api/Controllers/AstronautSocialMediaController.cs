using Astronauts.Api.Responses;
using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Astronauts.Infraestructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Astronauts.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AstronautSocialMediaController : ControllerBase
{
    private readonly IAstronautSocialMediaService _astronautSocialMediaService;
    private readonly IMapper _mapper;
    private readonly IUriService _uriService;
    public AstronautSocialMediaController(IAstronautSocialMediaService astronautSocialMediaService, IMapper mapper, IUriService uriService)
    {
        _astronautSocialMediaService = astronautSocialMediaService;
        _mapper = mapper;
        _uriService = uriService;
    }

    /// <summary>
    /// Retrieve all social Media for astronaut
    /// </summary>
    /// <param name="filters">Filters to apply</param>
    /// <returns></returns>

    [HttpGet]
    public IActionResult GetSocialMediaByAstronaut([FromQuery] BaseQueryFilter filters)
    {
        var socialMedia = _astronautSocialMediaService.GetSocialMediaByAstronaut(filters);
        var socialMediaDtos = _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedia);

        var metadata = new MetaData
        {
            TotalCount = socialMedia.TotalCount,
            PageSize = socialMedia.PageSize,
            CurrentPage = socialMedia.CurrentPage,
            TotalPages = socialMedia.TotalPages,
            HasPreviousPage = socialMedia.HasPreviousPage,
            HasNextPage = socialMedia.HasNextPage,
            //PreviousPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetSocialMedia)))?.ToString(),
            //NextPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetSocialMedia)))?.ToString()
        };

        var response = new ApiResponse<IEnumerable<SocialMediaDto>>(socialMediaDtos)
        {
            Meta = metadata
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAstronautSocialMedia(AstronautSocialMediaDto astronautSocialMediaDto)
    {
        var astronautSocialMedia = _mapper.Map<AstronautSocialMedia>(astronautSocialMediaDto);
        await _astronautSocialMediaService.PostAstronautSocialMedia(astronautSocialMedia);

        astronautSocialMediaDto = _mapper.Map<AstronautSocialMediaDto>(astronautSocialMedia);
        var response = new ApiResponse<AstronautSocialMediaDto>(astronautSocialMediaDto);
        return Ok(response);
    }
}
