using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using tinker.Application.DTOs.ProductDtos;
using tinker.Domain.Entities;

namespace tinker.Application.DTOs.CategoryDtos
{
    public class CategoryReadDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductReadDto> Products { get; set; }
    }
}
