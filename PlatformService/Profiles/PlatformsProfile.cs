using AutoMapper;
using microservice_prac.DTOs;
using microservice_prac.Models;

namespace microservice_prac.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();

            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
