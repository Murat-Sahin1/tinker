using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tinker.Application.DTOs.CategoryDtos;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;
using tinker.Persistence.Repositories;

namespace tinker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public ActionResult<List<CategoryReadDto>> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll().ToList();
            var mappedCategories = _mapper.Map<List<Category>, List<CategoryReadDto>>(categories);
            return Ok(mappedCategories);
        }

        [HttpGet("wproducts")]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAllCategoriesWithRelations()
        {
            var categories = await _categoryRepository.GetAllWithProductsAsync();

            var mappedCategories = _mapper.Map<List<Category>, List<CategoryReadDto>>(categories);

            return Ok(mappedCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryReadDto>(category));
        }

        [HttpGet("wproducts/{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetByIdWithRelations(int id)
        {
            var category = await _categoryRepository.GetByIdWithProductsAsync(id);
            return Ok(_mapper.Map<CategoryReadDto>(category));
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetByIdWithProductsAsync(id);

            if (category == null)
            {
                throw new Exception("Category is not found.");
            }

            var othersCategory = await _categoryRepository.GetByNameWithProductsAsync("Others");

            if(othersCategory == null)
            {
                throw new Exception("Others category could not be found.");
            }

            if (othersCategory.ID == category.ID)
            {
                throw new Exception("You cannot delete the others category.");
            }

            foreach(var item in category.Products)
            {
                item.Category = othersCategory;
                item.CategoryId = othersCategory.ID;
                await _categoryRepository.SaveAsync();
                othersCategory.Products.Add(item);
            }

            category.Products.Clear();

            bool isDeleted = _categoryRepository.Remove(category);
            await _categoryRepository.SaveAsync();

            return isDeleted;
        }
        [HttpPost("add")]
        public async Task<ActionResult<CategoryReadDto>> AddCategory(CategoryCreateDto newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);

            bool isAdded = await _categoryRepository.InsertAsync(category);
            await _categoryRepository.SaveAsync();

            var mappedCategory = _mapper.Map<CategoryReadDto>(category);

            return mappedCategory;
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<CategoryReadDto>> UpdateCategory(int id, CategoryCreateDto updatedCategory)
        {
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(id);

            var mappedCategory = _mapper.Map<Category>(updatedCategory);

            categoryToUpdate.Name= mappedCategory.Name;
            categoryToUpdate.Description= mappedCategory.Description;

            await _categoryRepository.SaveAsync();

            var finalCategory = await _categoryRepository.GetByIdAsync(id);
            var readCategory = _mapper.Map<CategoryReadDto>(finalCategory);

            return readCategory;
        }
    }
}
