using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Domain.Entities
{
    public class Seller
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ShopName { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
