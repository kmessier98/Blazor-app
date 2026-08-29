using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private AppDbContext _dbContext { get; set; }

        public UtilisateurRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Utilisateur>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> GetByAsync(Expression<Func<Utilisateur, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
        }
    }
}
