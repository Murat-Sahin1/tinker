using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tinker.Application.DTOs.CategoryDtos;
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
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAllCategoriesWithRelations()
        {
            var categories = await _categoryRepository.GetAllWithProductsAsync();

            var mappedCategories = _mapper.Map<List<Category>, List<CategoryReadDto>>(categories);

            return Ok(mappedCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetByIdWithRelations(int id)
        {
            var category = await _categoryRepository.GetByIdWithProductsAsync(id);
            return Ok(_mapper.Map<CategoryReadDto>(category));
        }

        [HttpGet("/nop")]
        public ActionResult<List<CategoryReadDto>> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll().ToList();
            var mappedCategories = _mapper.Map<List<Category>, List<CategoryReadDto>>(categories);
            return Ok(mappedCategories);
        }
    }
}
