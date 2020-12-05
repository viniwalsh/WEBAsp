using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Application.AppServices.Implementations
{
    public class PoderAppService : IPoderAppService
    {
        private readonly IMapper _mapper;
        private readonly IPoderService _poderService;

        public PoderAppService( IMapper mapper, IPoderService poderService)
        {
            _mapper = mapper;
            _poderService = poderService;
        }

        public async Task<IEnumerable<PoderViewModel>> GetAllAsync(string search)
        {
            var poderEntities = await _poderService.GetAllAsync(search);

            return _mapper.Map<IEnumerable<PoderViewModel>>(poderEntities);
        }

        public async Task<PoderViewModel> GetByIdAsync(int id)
        {
            var poderEntity = await _poderService.GetByIdAsync(id);

            return _mapper.Map<PoderViewModel>(poderEntity);
        }

        public async Task<int> AddAsync(PoderViewModel poderViewModel)
        {
            var poderEntity = _mapper.Map<PoderEntity>(poderViewModel);

            var id = await _poderService.AddAsync(poderEntity);

            return id;
        }

        public async Task EditAsync(PoderViewModel poderViewModel)
        {
            var poderEntity = _mapper.Map<PoderEntity>(poderViewModel);

            await _poderService.EditAsync(poderEntity);
        }

        public async Task RemoveAsync(PoderViewModel poderViewModel)
        {
            var poderEntity = _mapper.Map<PoderEntity>(poderViewModel);

            await _poderService.RemoveAsync(poderEntity);
        }
    }
}
