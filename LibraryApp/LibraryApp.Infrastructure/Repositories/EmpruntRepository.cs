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

        public async Task<Emprunt?> FindByIdAsync(int id)
        {
            var result = await _dbContext.Emprunts
                .Include(e => e.Exemplaire)
                    .ThenInclude(l => l.Livre)
                .Include(e => e.Membre)
                .SingleOrDefaultAsync(x => x.Id == id);

            return result;
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

        public async Task<Emprunt> EmprunterExemplaire(Exemplaire entity, int membreId)
        {
            entity.EstDisponible = false;

            var emprunt = new Emprunt
            {
                ExemplaireId = entity.Id,
                MembreId = membreId,
                DateEmprunt = DateTime.Now,
                DateRetour = null
            };

            await _dbContext.Emprunts.AddAsync(emprunt);
            await _dbContext.SaveChangesAsync();

            return emprunt;
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
