using API.DTOs;
using AutoMapper;
using Infrastructure.Data.Entities;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserEntity,MemberDTO>();
            CreateMap<CompanyEntity,CompanyDTO>();
            CreateMap<EventEntity,EventDTO>();
        }
    }
}