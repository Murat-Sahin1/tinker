using tinker.Application.DTOs.CategoryDtos;
using tinker.Domain.Entities;

namespace tinker.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepositoryAsync<Category>
    {
        public Task<Category> GetByIdWithProductsAsync(int id);
        public Task<Category> GetByNameWithProductsAsync(string name);
        public Task<List<Category>> GetAllWithProductsAsync();
    }
}
