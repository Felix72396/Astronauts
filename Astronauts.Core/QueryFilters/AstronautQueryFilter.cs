namespace Astronauts.Core.QueryFilters;

public class AstronautQueryFilter
{
    //public int AustronautId { get; set; }
    public string? Nacionality { get; set; }
    public bool? Status {  get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
