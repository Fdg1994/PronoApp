using AutoMapper;
using Core.Domain.Entities;
using Core.Models;

namespace Core.Configuration
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<BetEntity, Bet>().ReverseMap();
            CreateMap<CompanyEntity, Company>().ReverseMap();
            CreateMap<GameEntity, Game>().ReverseMap();
            CreateMap<EventEntity, SportEvent>().ReverseMap();
        }
    }
}