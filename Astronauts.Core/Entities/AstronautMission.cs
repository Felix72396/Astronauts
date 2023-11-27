namespace Astronauts.Core.Entities
{
    public class AstronautMission
    {
        //[Key]
        public int AstronautId { get; set; }
        public virtual Astronaut Astronaut { get; set; }

        //[Key]
        public int MissionId { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
