using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;
using tinker.Persistence.Repositories;

namespace tinker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public Task<IReadOnlyList<Product>> GetAllWithRelationsAsync()
        {
            return _productRepository.GetAllWithRelationsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            Console.WriteLine("getbyid");
            var product = await _productRepository.GetByIdWithRelationsAsync(id);
            return product;
        }
    }
}
