using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task EmprunterLivre(Livre entity, int utilisateurId)
        {
            entity.EstDisponible = false;
            entity.Emprunts.Add(new Emprunt()
            {
                LivreId = entity.Id,
                UtilisateurId = 1,
                DateEmprunt = DateTime.Now,
                DateRetour = null
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Livre?> FindByIdAsync(int id)
        {
            var result = await _dbContext.Livres.Where(l => l.Id == id)
                 .Include(e => e.Editeur)
                .Include(a => a.Auteurs)
                .Include(c => c.Categories)
                .Include(e => e.Emprunts)
                    .ThenInclude(u => u.Utilisateur)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<IReadOnlyList<Livre>> GetAllAsync()
        {
            var result = await _dbContext.Livres
                .Include(e => e.Editeur)
                .Include(a => a.Auteurs)
                .ToListAsync();

            return result;
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
