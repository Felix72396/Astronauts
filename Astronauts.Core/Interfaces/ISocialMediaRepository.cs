using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface ISocialMediaRepository
{
    Task<IEnumerable<SocialMedia>> GetSocialMediaByAstronaut(int id);
    Task<SocialMedia> GetById(int id);
    Task Post(SocialMedia entity);

    void Update(SocialMedia entity);
    Task Delete(int id);
}
