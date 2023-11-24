namespace Astronauts.Core.Entities;

public class SocialMedia : BaseEntity
{
    public SocialMedia() 
    {
        AstronautSocialMedia = new HashSet<AstronautSocialMedia>();
    }

    public string Description { get; set; }
    public virtual ICollection<AstronautSocialMedia> AstronautSocialMedia { get; set; }
}
