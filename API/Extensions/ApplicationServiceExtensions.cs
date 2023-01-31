using API.Interface;
using API.Services;
using Data.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUserEntityRepository, UserEntityRepository>();
            services.AddEndpointsApiExplorer();
            services.AddCors();
            services.AddScoped<ITokenService,TokenService>();

            return services;
        }
    }
}