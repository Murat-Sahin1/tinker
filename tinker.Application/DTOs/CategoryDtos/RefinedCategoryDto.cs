﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.DTOs.ProductDtos;

namespace tinker.Application.DTOs.CategoryDtos
{
    public class RefinedCategoryDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
