using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}