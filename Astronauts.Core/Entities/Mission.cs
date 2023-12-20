namespace Astronauts.Core.Entities;

public class Mission : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Astronaut> Astronauts { get; set; }
}
