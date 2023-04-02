using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Domain.Entities.Common;

namespace tinker.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
