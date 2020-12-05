using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class HeroiService : IHeroiService
    {
        private readonly IHeroiRepository _heroiRepository;

        public HeroiService(
            IHeroiRepository heroiRepository)
        {
            _heroiRepository = heroiRepository;
        }

        public async Task<IEnumerable<HeroiEntity>> GetAllAsync(string search)
        {
            return await _heroiRepository.GetAllAsync(search);
        }

        public async Task<HeroiEntity> GetByIdAsync(int id)
        {
            return await _heroiRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(HeroiEntity heroiEntity)
        {
            return await _heroiRepository.AddAsync(heroiEntity);
        }

        public async Task EditAsync(HeroiEntity heroiEntity)
        {
            await _heroiRepository.EditAsync(heroiEntity);
        }

        public async Task RemoveAsync(HeroiEntity heroiEntity)
        {
            await _heroiRepository.RemoveAsync(heroiEntity);
        }
    }
}
