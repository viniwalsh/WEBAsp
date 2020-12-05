using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices
{
    public interface IHeroiAppService
    {
        Task<IEnumerable<HeroiViewModel>> GetAllAsync(string search);
        Task<HeroiViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(HeroiViewModel heroiViewModel);
        Task EditAsync(HeroiViewModel heroiViewModel);
        Task RemoveAsync(HeroiViewModel heroiViewModel);
    }
}
