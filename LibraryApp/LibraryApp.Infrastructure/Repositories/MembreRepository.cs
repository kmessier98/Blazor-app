using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class MembreRepository : IMembreRepository
    {
        private AppDbContext _dbContext { get; set; }

        public MembreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Membre entity)
        {
            await _dbContext.Membres.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Membre entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Membre?> FindByIdAsync(int id)
        {
            var result = await _dbContext.Membres
                .Include(e => e.Emprunts)
                .SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IReadOnlyList<Membre>> GetAllAsync()
        {
            var result = await _dbContext.Membres
                    .Include(e => e.Emprunts)
                    .AsNoTracking().ToListAsync();

            return result;
        }

        public Task<Membre> GetByAsync(Expression<Func<Membre, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Membre entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByCourrielAsync(string courriel)
        {
            return await _dbContext.Membres
                .AnyAsync(m => m.Courriel == courriel);
        }
    }
}
