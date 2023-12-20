using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Astronauts.Core.Entities;

public partial class Astronaut : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public byte[]? Photo { get; set; } = null;

    public virtual ICollection<Mission> Missions { get; set; }
    public virtual ICollection<SocialMedia> SocialMedia { get; set; }

}
