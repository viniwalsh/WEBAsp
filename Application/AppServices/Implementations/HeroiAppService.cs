using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Application.AppServices.Implementations
{
    public class HeroiAppService : IHeroiAppService
    {
        private readonly IMapper _mapper;
        private readonly IHeroiService _heroiService;

        public HeroiAppService(
            IMapper mapper,
            IHeroiService heroiService)
        {
            _mapper = mapper;
            _heroiService = heroiService;
        }

        public async Task<IEnumerable<HeroiViewModel>> GetAllAsync(string search)
        {
            var heroiEntities = await _heroiService.GetAllAsync(search);

            return _mapper.Map<IEnumerable<HeroiViewModel>>(heroiEntities);
        }

        public async Task<HeroiViewModel> GetByIdAsync(int id)
        {
            var heroiEntity = await _heroiService.GetByIdAsync(id);

            return _mapper.Map<HeroiViewModel>(heroiEntity);
        }

        public async Task<int> AddAsync(HeroiViewModel heroiViewModel)
        {
            var heroiEntity = _mapper.Map<HeroiEntity>(heroiViewModel);

            var id = await _heroiService.AddAsync(heroiEntity);

            return id;
        }

        public async Task EditAsync(HeroiViewModel heroiViewModel)
        {
            var heroiEntity = _mapper.Map<HeroiEntity>(heroiViewModel);

            await _heroiService.EditAsync(heroiEntity);
        }

        public async Task RemoveAsync(HeroiViewModel heroiViewModel)
        {
            var heroiEntity = _mapper.Map<HeroiEntity>(heroiViewModel);

            await _heroiService.RemoveAsync(heroiEntity);
        }
    }
}
