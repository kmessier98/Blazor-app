using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class LivreRepository : ILivreRepository
    {
        private readonly AppDbContext _dbContext;

        public LivreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Livre entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Livre entity)
        {
            throw new NotImplementedException();
        }

        public Task<Livre> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Livre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Livre> GetByAsync(Expression<Func<Livre, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Livre entity)
        {
            throw new NotImplementedException();
        }
    }
}
