namespace Astronauts.Core.Entities;

public partial class Astronaut : BaseEntity
{
    public Astronaut()
    {
        AstronautMissions = new HashSet<AstronautMission>();
        AstronautSocialMedia = new HashSet<AstronautSocialMedia>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public string? Description { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public byte[]? Photo { get; set; }

    public virtual ICollection<AstronautMission> AstronautMissions { get; set; }
    public virtual ICollection<AstronautSocialMedia> AstronautSocialMedia { get; set; }

}
