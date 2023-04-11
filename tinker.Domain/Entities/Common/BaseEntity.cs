using System.ComponentModel.DataAnnotations;

namespace tinker.Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
