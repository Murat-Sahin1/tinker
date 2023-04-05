using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;

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
    }
}
