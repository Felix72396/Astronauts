using Astronauts.Core.QueryFilters;

namespace Astronauts.Infraestructure.Interfaces;

public interface IUriService
{
    Uri GetAstronautPaginationUri(AstronautQueryFilter filters, string actionUrl);
}