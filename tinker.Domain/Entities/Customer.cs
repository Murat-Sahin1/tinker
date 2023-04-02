using System.ComponentModel.DataAnnotations;
using tinker.Domain.Entities.Common;

namespace tinker.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
