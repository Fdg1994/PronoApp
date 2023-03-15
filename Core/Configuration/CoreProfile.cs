using AutoMapper;
using Core.Models;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class CoreProfile: Profile
    {
        public CoreProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<BetEntity, Bet>().ReverseMap();
            CreateMap<CompanyEntity, Company>().ReverseMap();
            CreateMap<GameEntity, Game>().ReverseMap();
        }
    }
}
