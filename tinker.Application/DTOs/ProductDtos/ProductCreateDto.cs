using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.DTOs.CategoryDtos;
using tinker.Application.DTOs.Common;
using tinker.Application.DTOs.SellerDtos;
using tinker.Domain.Enums;

namespace tinker.Application.DTOs.ProductDtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public int Sold { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int SellerID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public ProductStatus ProductStatus { get; set; }
    }
}
