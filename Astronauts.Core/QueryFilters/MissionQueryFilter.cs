namespace Astronauts.Core.QueryFilters;

public class MissionQueryFilter
{
    public int? AstronautId { get; set; }
    public int? MissionId { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
