using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductController (IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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
