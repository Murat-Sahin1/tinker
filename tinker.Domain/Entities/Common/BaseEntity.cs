using System.ComponentModel.DataAnnotations;

namespace tinker.Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
