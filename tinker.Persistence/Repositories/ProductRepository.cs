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
    public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllWithRelationsAsync()
        {
            return await GetAll()
                .AsNoTracking()
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByNameWithRelationsAsync(string name)
        {
            return await Table
                .AsNoTracking()
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Product> GetByIdWithRelationsAsync(int id)
        {
            return await Table
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
