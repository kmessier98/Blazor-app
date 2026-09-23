using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class EmpruntRepository : IEmpruntRepository
    {
        private readonly AppDbContext _dbContext;

        public EmpruntRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task CreateAsync(Emprunt entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Emprunt entity)
        {
            throw new NotImplementedException();
        }

        public Task<Emprunt?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Emprunt>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Emprunt> GetByAsync(Expression<Func<Emprunt, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Emprunt entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Emprunt>> GetAllActiveAsync()
        {
            var result = await _dbContext.Emprunts
                .Where(e => e.DateRetour == null)
                .Include(ex => ex.Exemplaire)
                    .ThenInclude(l => l.Livre)
                .Include(u => u.Membre)
                .ToListAsync();

            return result;
        }


        public async Task RetournerExemplaire(Emprunt entity)
        {
            entity.DateRetour = DateTime.Now;
            entity.Exemplaire.EstDisponible = true;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Emprunt?> GetActiveAsync(int empruntId)
        {
            var result = await _dbContext.Emprunts
              .Where(x => x.Id == empruntId && x.DateRetour == null)
              .Include(e => e.Exemplaire)
                .ThenInclude(l => l.Livre)
              .SingleOrDefaultAsync();

            return result;
        }
    }
}
