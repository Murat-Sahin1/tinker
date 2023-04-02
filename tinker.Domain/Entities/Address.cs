using tinker.Domain.Entities.Common;

namespace tinker.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}
