using Application.AppServices;
using Application.AppServices.Implementations;
using AutoMapper;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Service.Services;
using Infrastructure.Crosscutting.IoC.MappingProfiles;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Crosscutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterBibliotecaServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IHeroiAppService, HeroiAppService>();
            services.AddScoped<IPoderAppService, PoderAppService>();

            services.AddScoped<IHeroiService, HeroiService>();
            services.AddScoped<IPoderService, PoderService>();

            services.AddScoped<IHeroiRepository, HeroiRepository>();
            services.AddScoped<IPoderRepository, PoderRepository>();

            services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BibliotecaContext")));

            services.AddAutoMapper(x => x.AddProfile(typeof(MappingProfile)));
        }
    }
}
