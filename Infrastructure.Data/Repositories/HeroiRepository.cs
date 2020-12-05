using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class HeroiRepository : IHeroiRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public HeroiRepository(
            BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public async Task<IEnumerable<HeroiEntity>> GetAllAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return _bibliotecaContext.Herois;
            }

            return _bibliotecaContext.Herois.Where(x => x.Nome.Contains(search));
        }

        public async Task<HeroiEntity> GetByIdAsync(int id)
        {
            return await _bibliotecaContext.Herois.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(HeroiEntity heroiEntity)
        {
            var entityEntry = await _bibliotecaContext.Herois.AddAsync(heroiEntity);

            await _bibliotecaContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(HeroiEntity heroiEntity)
        {
            _bibliotecaContext.Herois.Update(heroiEntity);

            await _bibliotecaContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(HeroiEntity heroiEntity)
        {
            var heroiToRemove = await GetByIdAsync(heroiEntity.Id);

            _bibliotecaContext.Herois.Remove(heroiToRemove);

            await _bibliotecaContext.SaveChangesAsync();
        }
    }
}
