using Astronauts.Core.CustomEntities;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;
using Astronauts.Core.QueryFilters;

namespace Astronauts.Core.Interfaces;

public interface IAstronautSocialMediaService
{
    PagedList<CustomSocialMediaDto> GetSocialMediaByAstronaut(BaseQueryFilter filters);
    Task PostAstronautSocialMedia(AstronautSocialMedia astronautSocialMedia);
}
