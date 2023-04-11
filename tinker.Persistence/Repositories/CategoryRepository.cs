using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.DTOs.CategoryDtos;
using tinker.Application.Interfaces.Repositories;

using tinker.Domain.Entities;
using tinker.Persistence.Contexts;


namespace tinker.Persistence.Repositories
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public CategoryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Category> GetByIdWithProductsAsync(int id)
        {
            return await Table
                .AsNoTracking()
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<Category> GetByNameWithProductsAsync(string name)
        {
            return await Table
                .AsNoTracking()
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<List<Category>> GetAllWithProductsAsync()
        {
            return await GetAll()
                .AsNoTracking()
                .Include(c => c.Products)
                .ToListAsync();
        }
    }
}
