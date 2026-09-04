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

        public Task CreateAsync(Membre entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Membre entity)
        {
            throw new NotImplementedException();
        }

        public Task<Membre?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Membre>> GetAllAsync()
        {
            var result = await _dbContext.Membres.AsNoTracking().ToListAsync();

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
    }
}
