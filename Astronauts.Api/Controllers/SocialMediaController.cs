using Astronauts.Api.Responses;
using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.QueryFilters;
using Astronauts.Infraestructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net;

namespace Astronauts.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaController : ControllerBase
{
    private readonly ISocialMediaService _socialMediaService;
    private readonly IMapper _mapper;
    public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
    {
        _socialMediaService = socialMediaService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieve all social media
    /// </summary>
    /// <param name="filters">Filters to apply</param>
    /// <returns></returns>

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<SocialMediaDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult GetAllByAstronautId([FromQuery] int astronautId)
    {
        var socialMedia = _socialMediaService.GetSocialMediaByAstronaut(astronautId);
        var socialMediaDtos = _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedia);

        var response = new ApiResponse<IEnumerable<SocialMediaDto>>(socialMediaDtos);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SocialMediaDto socialMediaDto)
    {
        var socialMedia = _mapper.Map<SocialMedia>(socialMediaDto);
        await _socialMediaService.PostSocialMedia(socialMedia);

        socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
        var response = new ApiResponse<SocialMediaDto>(socialMediaDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, SocialMediaDto postDto)
    {
        var post = _mapper.Map<SocialMedia>(postDto);
        post.Id = id;
        var result = await _socialMediaService.UpdateSocialMedia(post);
        var response = new ApiResponse<bool>(result);
        return Ok(post);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _socialMediaService.DeleteSocialMedia(id);
        var response = new ApiResponse<bool>(result);

        return Ok(response);
    }
}