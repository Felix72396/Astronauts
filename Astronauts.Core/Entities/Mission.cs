namespace Astronauts.Core.Entities;

public class Mission : BaseEntity
{
    public Mission()
    {
        Astronauts = new HashSet<Astronaut>();
    }

    public string Description { get; set; }
    public virtual ICollection<Astronaut> Astronauts { get; set; }
}
