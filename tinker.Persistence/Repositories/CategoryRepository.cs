using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;
using tinker.Persistence.Contexts;

namespace tinker.Persistence.Repositories
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> GetByIdWithProductsAsync(int id)
        {
            return await Table
                .Include(c => c.Products)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<Category> GetByNameWithProductsAsync(string name)
        {
            return await Table
                .Include(c => c.Products)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
