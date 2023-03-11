using API.DTOs;
using AutoMapper;
using Infrastructure.Data.Entities;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserEntity, MemberDTO>().ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));
            CreateMap<CompanyEntity, CompanyDTO>().ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members.Select(m => new MemberDTO
            {
                Username = m.UserName,
                Email = m.Email,
                PictureUrl = m.PictureUrl,
                Branch = m.Branch,
                Points = m.Points,
                CompanyRole = m.CompanyRole.ToString(),          
            })));
            CreateMap<EventEntity, EventDTO>();
        }
    }
}