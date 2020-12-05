using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IPoderRepository
    {
        Task<IEnumerable<PoderEntity>> GetAllAsync(string search);
        Task<PoderEntity> GetByIdAsync(int id);
        Task<int> AddAsync(PoderEntity poderEntity);
        Task EditAsync(PoderEntity poderEntity);
        Task RemoveAsync(PoderEntity poderEntity);
    }
}
