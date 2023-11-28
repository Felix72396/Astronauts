using Astronauts.Api.Responses;
using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Astronauts.Infraestructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Astronauts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautSocialMediaController : ControllerBase
    {
        private readonly IAstronautMissionService _astronautMissionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public AstronautSocialMediaController(IAstronautMissionService astronautMissionService, IMapper mapper, IUriService uriService)
        {
            _astronautMissionService = astronautMissionService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all missions for astronaut
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetMissionsByAstronaut([FromQuery] BaseQueryFilter filters)
        {
            var missions = _astronautMissionService.GetMissionsByAstronaut(filters);
            var missionDtos = _mapper.Map<IEnumerable<MissionDto>>(missions);

            var metadata = new MetaData
            {
                TotalCount = missions.TotalCount,
                PageSize = missions.PageSize,
                CurrentPage = missions.CurrentPage,
                TotalPages = missions.TotalPages,
                HasPreviousPage = missions.HasPreviousPage,
                HasNextPage = missions.HasNextPage,
                //PreviousPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetMissions)))?.ToString(),
                //NextPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetMissions)))?.ToString()
            };

            var response = new ApiResponse<IEnumerable<MissionDto>>(missionDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAstronautMission(AstronautMissionDto astronautMissionDto)
        {
            var astronautMission = _mapper.Map<AstronautMission>(astronautMissionDto);
            await _astronautMissionService.PostAstronautMission(astronautMission);

            astronautMissionDto = _mapper.Map<AstronautMissionDto>(astronautMission);
            var response = new ApiResponse<AstronautMissionDto>(astronautMissionDto);
            return Ok(response);
        }
    }
}
