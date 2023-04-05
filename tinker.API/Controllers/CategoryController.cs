using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;
using tinker.Persistence.Repositories;

namespace tinker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        

        [HttpGet("{id}")]
        public Task<Category> GetById(int id)
        {
            Console.WriteLine("getbyid");
            var category = _categoryRepository.GetByIdWithProductsAsync(id);
            return category;
        }
    }
}
