using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface IAstronautSocialMediaRepository
{
    Task<IEnumerable<SocialMedia>> GetSocialMediaByAstronaut(int astronautId);
    Task Post(AstronautSocialMedia astronautSocialMedia);
}
