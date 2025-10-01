using AutoMapper;
using RallyChampAPI.Entities;
using RallyChampAPI.Models;

namespace RallyChampAPI.MappingProfiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultDto>();
            CreateMap<CreateResultDto, Result>();
        }
    }
}