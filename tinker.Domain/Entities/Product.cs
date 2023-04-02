using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Domain.Enums;

namespace tinker.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Image> Images { get; set; }
        public int Sold { get; set; }
        public decimal Price { get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }
        public int InStock { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
