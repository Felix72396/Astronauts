namespace Astronauts.Core.QueryFilters;

public class AstronautQueryFilter
{
    public int? AstronautId { get; set; }
    public string? Nationality { get; set; }
    public bool? Status {  get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
