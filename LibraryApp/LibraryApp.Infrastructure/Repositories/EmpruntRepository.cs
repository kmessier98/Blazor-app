using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class EmpruntRepository : IEmpruntRepository
    {
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

        public Task<IReadOnlyList<Emprunt>> GetAllActiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
