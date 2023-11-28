using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.QueryFilters;

namespace Astronauts.Core.Interfaces;

public interface ISocialMediaService
{
    PagedList<SocialMedia> GetSocialMedia(BaseQueryFilter filters);
    Task<SocialMedia> GetSocialMedia(int id);
    Task PostSocialMedia(SocialMedia socialMedia);
}
