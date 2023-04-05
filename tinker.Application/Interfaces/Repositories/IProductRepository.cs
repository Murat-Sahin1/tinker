using tinker.Domain.Entities;

namespace tinker.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
        public Task<IReadOnlyList<Product>> GetAllWithRelationsAsync();
        public Task<Product> GetByIdWithRelationsAsync(int id);
    }
}
