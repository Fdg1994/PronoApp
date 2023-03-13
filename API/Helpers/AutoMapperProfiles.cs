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

            CreateMap<GameEntity, GameDTO>().ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event));
            CreateMap<EventEntity, EventDTO>().ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Games.Select(g => new GameDTO
            {
                Name = g.Name,
                Status = g.Status.ToString(),
                StartTimeGame = g.StartTimeGame,
                EndTimeGame = g.EndTimeGame,
                Team1 = g.Team1,
                Team2 = g.Team2,
                Team1Score = g.Team1Score,
                Team2Score = g.Team1Score      
            })));;
        }
    }
}