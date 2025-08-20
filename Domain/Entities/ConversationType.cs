using System.ComponentModel.DataAnnotations;

namespace ChatAll.Domain.Entities
{
    public class ConversationType
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
