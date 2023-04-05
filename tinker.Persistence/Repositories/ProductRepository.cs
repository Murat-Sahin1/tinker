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
        public async Task<IReadOnlyList<Product>> GetAllWithRelationsAsync()
        {
            return await GetAll()
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetByIdWithRelationsAsync(int id)
        {
            return await Table
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
