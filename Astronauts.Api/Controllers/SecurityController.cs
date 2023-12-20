using Astronauts.Api.Responses;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.Enumerations;
using Astronauts.Core.Interfaces;
using Astronauts.Infraestructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Astronauts.Api.Controllers;

//[Authorize(Roles = nameof(RoleType.Administrator))]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    private readonly IPasswordService _passwordService;
    private readonly IMapper _mapper;

    public SecurityController(ISecurityService securityService, IPasswordService passwordService, IMapper mapper)
    {
        _securityService = securityService;
        _passwordService = passwordService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SecurityDto securityDto)
    {
        var security = _mapper.Map<Security>(securityDto);

        security.Password = _passwordService.Hash(security.Password);

        await _securityService.RegisterUser(security);

        securityDto = _mapper.Map<SecurityDto>(security);
        var response = new ApiResponse<SecurityDto>(securityDto);
        return Ok(response);
    }
}
