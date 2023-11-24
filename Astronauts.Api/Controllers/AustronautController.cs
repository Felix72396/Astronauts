
using Astronauts.Api.Responses;
using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Astronauts.Infraestructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;


namespace Astronauts.Api.Controllers;
[Authorize]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class AstronautController : ControllerBase
{
    private readonly IAstronautService _astronautService;
    private readonly IMapper _mapper;
    private readonly IUriService _uriService;
    public AstronautController(IAstronautService astronautService, IMapper mapper, IUriService uriService)
    {
        _astronautService = astronautService;
        _mapper = mapper;
        _uriService = uriService;
    }

    /// <summary>
    /// Retrieve all astronauts
    /// </summary>
    /// <param name="filters">Filters to apply</param>
    /// <returns></returns>
    [HttpGet(Name = nameof(GetAll))]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AstronautDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult GetAll([FromQuery] AstronautQueryFilter filters)
    {
        var astronauts = _astronautService.GetAll(filters);
        var astronautDtos = _mapper.Map<IEnumerable<AstronautDto>>(astronauts);

        var metadata = new MetaData
        {
            TotalCount = astronauts.TotalCount,
            PageSize = astronauts.PageSize,
            CurrentPage = astronauts.CurrentPage,
            TotalPages = astronauts.TotalPages,
            HasPreviousPage = astronauts.HasPreviousPage,
            HasNextPage = astronauts.HasNextPage,
            PreviousPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetAll)))?.ToString(),
            NextPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetAll)))?.ToString()
        };

        var response = new ApiResponse<IEnumerable<AstronautDto>>(astronautDtos)
        {
            Meta = metadata
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var astronaut = await _astronautService.GetById(id);
        var astronautDto = _mapper.Map<AstronautDto>(astronaut);
        var response = new ApiResponse<AstronautDto>(astronautDto);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AstronautDto astronautDto)
    {
        var astronaut = _mapper.Map<Astronaut>(astronautDto);
        await _astronautService.Post(astronaut);

        astronautDto = _mapper.Map<AstronautDto>(astronaut);
        var response = new ApiResponse<AstronautDto>(astronautDto);
        return Ok(response);
    }
}
