namespace Astronauts.Core.QueryFilters;

public class AstronautQueryFilter : BaseQueryFilter
{
    public string? Nationality { get; set; }
    public bool? Status { get; set; }
}
