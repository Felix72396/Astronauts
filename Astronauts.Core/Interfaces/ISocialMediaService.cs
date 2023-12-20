using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface ISocialMediaService
{
    IEnumerable<SocialMedia> GetSocialMediaByAstronaut(int id);
    Task PostSocialMedia(SocialMedia socialMedia);
    Task<bool> UpdateSocialMedia(SocialMedia socialMedia);
    Task<bool> DeleteSocialMedia(int id);

}
