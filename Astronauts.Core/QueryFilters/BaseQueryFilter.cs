namespace Astronauts.Core.QueryFilters;

public class BaseQueryFilter
{
    public int? AstronautId { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
