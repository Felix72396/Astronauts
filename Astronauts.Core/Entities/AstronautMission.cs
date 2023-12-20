namespace Astronauts.Core.Entities
{
    public class AstronautMission
    {
        public int AstronautId { get; set; }
        public virtual Astronaut Astronaut { get; set; }

        public int MissionId { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
