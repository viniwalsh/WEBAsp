using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface IHeroiService
    {
        Task<IEnumerable<HeroiEntity>> GetAllAsync(string search);
        Task<HeroiEntity> GetByIdAsync(int id);
        Task<int> AddAsync(HeroiEntity heroiEntity);
        Task EditAsync(HeroiEntity heroiEntity);
        Task RemoveAsync(HeroiEntity heroiEntity);
    }
}
