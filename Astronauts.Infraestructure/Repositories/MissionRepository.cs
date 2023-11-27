using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Astronauts.Infraestructure.Repositories;

public class MissionRepository : BaseRepository<Mission>, IMissionRepository
{
    public MissionRepository(AstronautMediaContext context) : base(context) { }
}