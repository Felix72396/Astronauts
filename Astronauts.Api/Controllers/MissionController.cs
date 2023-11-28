using Astronauts.Api.Responses;
using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
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
        public IActionResult GetMissions([FromQuery] BaseQueryFilter filters)
        {
            var missions = _missionService.GetMissions(filters);
            var missionDtos = _mapper.Map<IEnumerable<MissionDto>>(missions);

            var metadata = new MetaData
            {
                TotalCount = missions.TotalCount,
                PageSize = missions.PageSize,
                CurrentPage = missions.CurrentPage,
                TotalPages = missions.TotalPages,
                HasPreviousPage = missions.HasPreviousPage,
                HasNextPage = missions.HasNextPage
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMission(int id)
        {
            var mission = await _missionService.GetMission(id);
            var missionDto = _mapper.Map<MissionDto>(mission);
            var response = new ApiResponse<MissionDto>(missionDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostMission(MissionDto missionDto)
        {
            var mission = _mapper.Map<Mission>(missionDto);
            await _missionService.PostMission(mission);

            missionDto = _mapper.Map<MissionDto>(mission);
            var response = new ApiResponse<MissionDto>(missionDto);
            return Ok(response);
        }

       
    }
}
