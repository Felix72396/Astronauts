using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface IAstronautSocialMediaRepository
{
    Task<IEnumerable<CustomSocialMediaDto>> GetSocialMediaByAstronaut(int astronautId);
    Task Post(AstronautSocialMedia astronautSocialMedia);
}
