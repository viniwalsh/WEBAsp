using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PoderRepository : IPoderRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public PoderRepository(
            BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public async Task<IEnumerable<PoderEntity>> GetAllAsync(string search)
        {
            var poderesComHerois = _bibliotecaContext
                .Poderes
                .Include(x => x.Heroi);

            if (string.IsNullOrWhiteSpace(search))
            {
                return poderesComHerois;
            }

            return poderesComHerois.Where(x => x.Nome.Contains(search));
        }

        public async Task<PoderEntity> GetByIdAsync(int id)
        {
            return await _bibliotecaContext.Poderes
                .Include(x => x.Heroi)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(PoderEntity heroiEntity)
        {
            var entityEntry = await _bibliotecaContext.Poderes.AddAsync(heroiEntity);

            await _bibliotecaContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(PoderEntity heroiEntity)
        {
            _bibliotecaContext.Poderes.Update(heroiEntity);

            await _bibliotecaContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(PoderEntity heroiEntity)
        {
            var poderToRemove = await GetByIdAsync(heroiEntity.Id);

            _bibliotecaContext.Poderes.Remove(poderToRemove);

            await _bibliotecaContext.SaveChangesAsync();
        }
    }
}
