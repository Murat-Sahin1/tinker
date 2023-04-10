using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.DTOs.Common;
using tinker.Application.DTOs.ProductDtos;
using tinker.Domain.Entities;

namespace tinker.Application.DTOs.SellerDtos
{
    public class SellerReadDto
    {

        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ShopName { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<ProductReadDto> Products { get; set; }
    }
}
