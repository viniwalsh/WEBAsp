using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices
{
    public interface IPoderAppService
    {
        Task<IEnumerable<PoderViewModel>> GetAllAsync(string search);
        Task<PoderViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(PoderViewModel poderViewModel);
        Task EditAsync(PoderViewModel poderViewModel);
        Task RemoveAsync(PoderViewModel poderViewModel);
    }
}
