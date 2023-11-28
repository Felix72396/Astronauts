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
using System.Net;

namespace Astronauts.Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper, IUriService uriService)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all social media
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetSocialMedia))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<SocialMediaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetSocialMedia([FromQuery] BaseQueryFilter filters)
        {
            var socialMedia = _socialMediaService.GetSocialMedia(filters);
            var socialMediaDtos = _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedia);

            var metadata = new MetaData
            {
                TotalCount = socialMedia.TotalCount,
                PageSize = socialMedia.PageSize,
                CurrentPage = socialMedia.CurrentPage,
                TotalPages = socialMedia.TotalPages,
                HasPreviousPage = socialMedia.HasPreviousPage,
                HasNextPage = socialMedia.HasNextPage
                //PreviousPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetMissions)))?.ToString(),
                //NextPageUrl = _uriService?.GetAstronautPaginationUri(filters, Url?.RouteUrl(nameof(GetMissions)))?.ToString()
            };

            var response = new ApiResponse<IEnumerable<SocialMediaDto>>(socialMediaDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var socialMedia = await _socialMediaService.GetSocialMedia(id);
            var socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            var response = new ApiResponse<SocialMediaDto>(socialMediaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostSocialMedia(SocialMediaDto socialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(socialMediaDto);
            await _socialMediaService.PostSocialMedia(socialMedia);

            socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            var response = new ApiResponse<SocialMediaDto>(socialMediaDto);
            return Ok(response);
        }

    }
}
