using AutoMapper;
using RallyChampAPI.Entities;
using RallyChampAPI.Models;

namespace RallyChampAPI.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<CreateTeamDto, Team>();
        }
    }
}