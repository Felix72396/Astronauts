using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;

namespace Astronauts.Infraestructure.Repositories
{
    public class SocialMediaRepository : BaseRepository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(AstronautMediaContext context) : base(context) { }
    }
}
