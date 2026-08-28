using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class AuteurRepository : IAuteurRepository
    {
        private readonly AppDbContext _dbContext;

        public AuteurRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task CreateAsync(Auteur entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Auteur entity)
        {
            throw new NotImplementedException();
        }

        public Task<Auteur> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Auteur>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Auteur> GetByAsync(Expression<Func<Auteur, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Auteur entity)
        {
            throw new NotImplementedException();
        }
    }
}
