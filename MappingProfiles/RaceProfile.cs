using AutoMapper;
using RallyChampAPI.Entities;
using RallyChampAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RallyChampAPI.MappingProfiles
{
    public class RaceProfile : Profile
    {
        public RaceProfile()
        {
            CreateMap<Race, RaceDto>();
            CreateMap<CreateRaceDto, Race>();
        }
    }
}