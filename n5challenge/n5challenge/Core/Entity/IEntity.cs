using System.ComponentModel.DataAnnotations;

namespace n5challenge.Core.Entity
{
    public record IEntity
    {
        [Key]
        public int Id { get; set; }
        //////public DateTime CreatedAt { get; set; }
        //////public DateTime UpdatedAt { get; set; }
    }
}
