namespace Astronauts.Core.Entities;

public class AstronautSocialMedia
{
    public int AstronautId { get; set; }
    public virtual Astronaut Astronaut { get; set; }

    public int SocialMediaId { get; set; }
    public virtual SocialMedia SocialMedia { get; set; }

    public int Link { get; set; }
    
   
}
