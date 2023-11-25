using Astronauts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astronauts.Core.Interfaces;

public interface IAstronautRepository : IRepository<Astronaut>
{
    //Task<Mission> GetMissionsByAstronaut();
}

