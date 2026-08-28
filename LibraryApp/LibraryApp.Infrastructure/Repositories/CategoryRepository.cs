using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(Categorie entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Categorie entity)
        {
            throw new NotImplementedException();
        }

        public Task<Categorie> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Categorie>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public Task<Categorie> GetByAsync(Expression<Func<Categorie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Categorie entity)
        {
            throw new NotImplementedException();
        }
    }
}
