using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}