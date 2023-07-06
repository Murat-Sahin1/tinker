using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Domain.Entities.Common;
using tinker.Domain.Enums;

namespace tinker.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ModelID { get; set; }
        public ICollection<Image> Images { get; set; }
        public int Sold { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public ProductStatus ProductStatus { get; set; }
    }
}
