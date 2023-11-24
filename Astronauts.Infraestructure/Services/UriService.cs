using Astronauts.Core.QueryFilters;
using Astronauts.Infraestructure.Interfaces;

namespace Astronauts.Infraestructure.Services;

public class UriService : IUriService
{
    private readonly string _baseUri;
    public UriService(string baseUri)
    {
        _baseUri = baseUri;
    }

    public Uri GetAstronautPaginationUri(AstronautQueryFilter filters, string actionUrl)
    {
        string baseUrl = $"{_baseUri}{actionUrl}";
        return new Uri(baseUrl);
    }
}
