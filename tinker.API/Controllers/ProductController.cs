using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tinker.Application.DTOs.ProductDtos;
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
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;
        public ProductController (IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<List<ProductReadDto>> GetAllProducts()
        {
            var products = _productRepository.GetAll().ToList();
            var mappedProducts = _mapper.Map<List<Product>, List<ProductReadDto>>(products);
            return Ok(mappedProducts);
        }

        [HttpGet("wrelations")]
        public async Task<ActionResult<List<ProductReadDto>>> GetAllProductsWithRelations()
        {
            var products = await _productRepository.GetAllWithRelationsAsync();
            var mappedProducts = _mapper.Map<List<Product>, List<ProductReadDto>>(products);
            return Ok(mappedProducts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetByIdAsync(int id)
        {
            var Product = await _productRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductReadDto>(Product));
        }

        [HttpGet("wproducts/{id}")]
        public async Task<ActionResult<ProductReadDto>> GetByIdWithRelations(int id)
        {
            var Product = await _productRepository.GetByIdWithRelationsAsync(id);
            return Ok(_mapper.Map<ProductReadDto>(Product));
        }
        
        
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdWithRelationsAsync(id);

            if (product == null)
            {
                throw new Exception("Product is not found.");
            }

            bool isDeleted = _productRepository.Remove(product);
            await _productRepository.SaveAsync();

            return isDeleted;
        }

        
        [HttpPost("add")]
        public async Task<ActionResult<ProductReadDto>> AddProduct(ProductCreateDto newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);
            
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);

            product.Category = category;
            product.Category.Products = null;

            bool isAdded = await _productRepository.InsertAsync(product);
            await _productRepository.SaveAsync();

            var mappedProduct = _mapper.Map<ProductReadDto>(product);

            return mappedProduct;
        }

        
        [HttpPut("update/{id}")]
        public async Task<ActionResult<ProductReadDto>> UpdateProduct(int id, ProductCreateDto updatedProduct)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);

            var mappedProduct = _mapper.Map<Product>(updatedProduct);

            productToUpdate.Name = mappedProduct.Name;
            productToUpdate.Description = mappedProduct.Description;
            productToUpdate.Category = mappedProduct.Category;
            productToUpdate.ProductStatus = mappedProduct.ProductStatus;
            productToUpdate.CategoryId = mappedProduct.CategoryId;
            productToUpdate.Images = mappedProduct.Images;
            productToUpdate.Sold = mappedProduct.Sold;
            productToUpdate.Price= mappedProduct.Price;

            

            await _productRepository.SaveAsync();

            var finalProduct = await _productRepository.GetByIdWithRelationsAsync(id);
            var readProduct = _mapper.Map<ProductReadDto>(finalProduct);

            return readProduct;
        }
    }
}
