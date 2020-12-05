using Application.ViewModels;
using AutoMapper;
using Domain.Model.Models;

namespace Infrastructure.Crosscutting.IoC.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HeroiViewModel, HeroiEntity>().ReverseMap();
            CreateMap<PoderViewModel, PoderEntity>().ReverseMap();
        }
    }
}
