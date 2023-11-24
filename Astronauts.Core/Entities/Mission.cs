namespace Astronauts.Core.Entities;

public class Mission : BaseEntity
{
    public Mission() 
    {
        AstronautMissions = new HashSet<AstronautMission>();
    }

    public string Description { get; set; }
    public virtual ICollection<AstronautMission> AstronautMissions { get; set; }
}
