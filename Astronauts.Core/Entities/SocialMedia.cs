namespace Astronauts.Core.Entities;

public class SocialMedia : BaseEntity
{
    public int AstronautId { get; set; }
    public virtual Astronaut Astronaut { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
}
