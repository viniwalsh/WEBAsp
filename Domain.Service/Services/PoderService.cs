using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class PoderService : IPoderService
    {
        private readonly IPoderRepository _poderRepository;

        public PoderService(
            IPoderRepository poderRepository)
        {
            _poderRepository = poderRepository;
        }

        public async Task<IEnumerable<PoderEntity>> GetAllAsync(string search)
        {
            return await _poderRepository.GetAllAsync(search);
        }

        public async Task<PoderEntity> GetByIdAsync(int id)
        {
            return await _poderRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(PoderEntity poderEntity)
        {
            return await _poderRepository.AddAsync(poderEntity);
        }

        public async Task EditAsync(PoderEntity poderEntity)
        {
            await _poderRepository.EditAsync(poderEntity);
        }

        public async Task RemoveAsync(PoderEntity poderEntity)
        {
            await _poderRepository.RemoveAsync(poderEntity);
        }

    }
}
