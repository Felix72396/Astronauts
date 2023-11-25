using Astronauts.Api.Responses;
using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Astronauts.Core.Services;
using Astronauts.Infraestructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Astronauts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public MissionController(IMissionService missionService, IMapper mapper, IUriService uriService)
        {
            _missionService = missionService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all missions
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetMissions))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<MissionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetMissions([FromQuery] MissionQueryFilter filters)
        {
            var astronauts = _missionService.GetMissions(filters);
            var astronautDtos = _mapper.Map<IEnumerable<MissionDto>>(astronauts);

            var metadata = new MetaData
            {
                TotalCount = astronauts.TotalCount,
                PageSize = astronauts.PageSize,
                CurrentPage = astronauts.CurrentPage,
                TotalPages = astronauts.TotalPages,
                HasPreviousPage = astronauts.HasPreviousPage,
                HasNextPage = astronauts.HasNextPage,
                //PreviousPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetMissions)))?.ToString(),
                //NextPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetMissions)))?.ToString()
            };

            var response = new ApiResponse<IEnumerable<MissionDto>>(astronautDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
    }
}
