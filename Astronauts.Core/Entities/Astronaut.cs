namespace Astronauts.Core.Entities;

public partial class Astronaut : BaseEntity
{
    public Astronaut()
    {
        Missions = new HashSet<Mission>();
        SocialMedia = new HashSet<SocialMedia>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public string? Description { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public byte[]? Photo { get; set; } = null;

    public virtual ICollection<Mission> Missions { get; set; }
    public virtual ICollection<SocialMedia> SocialMedia { get; set; }

}
