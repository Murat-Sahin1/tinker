using System.ComponentModel.DataAnnotations;
using tinker.Application.DTOs.CategoryDtos;
using tinker.Application.DTOs.Common;
using tinker.Application.DTOs.SellerDtos;
using tinker.Domain.Entities;
using tinker.Domain.Enums;

namespace tinker.Application.DTOs.ProductDtos
{
    public class ProductReadDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ModelID { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public int Sold { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public SellerReadDto Seller { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public RefinedCategoryDto Category { get; set; }
        [Required]
        public ProductStatus ProductStatus { get; set; }
    }
}