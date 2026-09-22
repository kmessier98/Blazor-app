using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class ExemplaireRepository : IExemplaireRepository
    {
        private readonly AppDbContext _dbContext;

        public ExemplaireRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Exemplaire entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Exemplaire entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Exemplaire?> FindByIdAsync(int id)
        {
            var result = await _dbContext.Exemplaires
                .Include(e => e.Livre)
                    .ThenInclude(l => l.Exemplaires)
                        .ThenInclude(e => e.Emprunts)
                .SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public Task<IReadOnlyList<Exemplaire>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exemplaire> GetByAsync(Expression<Func<Exemplaire, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Exemplaire entity)
        {
            throw new NotImplementedException();
        }

        public async Task EmprunterExemplaire(Exemplaire entity, int membreId)
        {
            entity.EstDisponible = false;

            await _dbContext.Emprunts.AddAsync(new Emprunt
            {
                ExemplaireId = entity.Id,
                MembreId = membreId,
                DateEmprunt = DateTime.Now,
                DateRetour = null
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
