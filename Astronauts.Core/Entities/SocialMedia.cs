namespace Astronauts.Core.Entities;

public class SocialMedia : BaseEntity
{
    public SocialMedia()
    {
        Astronauts = new HashSet<Astronaut>();
    }

    public string Description { get; set; }
    public virtual ICollection<Astronaut> Astronauts { get; set; }
}
