

using AutoMapper;
using Astronauts.Core.DTOs;
using Astronauts.Core.Entities;

namespace Astronauts.Infraestructure.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Astronaut, AstronautDto>().ReverseMap();
        CreateMap<Security, SecurityDto>().ReverseMap();
    }
}
