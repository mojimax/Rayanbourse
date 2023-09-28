using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string? CreateById { get; set; }
        public bool Deleted { get; set; }
    }

}
