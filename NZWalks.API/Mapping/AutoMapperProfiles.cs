using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegionDto, Region>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddwalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<DifficultyDto, Difficulty>().ReverseMap();
            CreateMap<UpdateWalkDto, Walk>().ReverseMap();
        }
    }
}
