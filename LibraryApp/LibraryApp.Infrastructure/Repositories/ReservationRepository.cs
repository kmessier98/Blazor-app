using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _dbContext;

        public ReservationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Reservation entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation?> FindByIdAsync(int id)
        {
            var result = await _dbContext.Reservations
                 .Include(x => x.Livre)
                 .Include(x => x.Membre)
                 .SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public Task<IReadOnlyList<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByAsync(Expression<Func<Reservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
