using tinker.Domain.Entities;

namespace tinker.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
        public Task<List<Product>> GetAllWithRelationsAsync();
        public Task<Product> GetByNameWithRelationsAsync(string name);
        public Task<Product> GetByIdWithRelationsAsync(int id);
    }
}
