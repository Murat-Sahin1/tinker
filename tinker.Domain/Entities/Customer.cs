using tinker.Domain.Entities.Common;

namespace tinker.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
