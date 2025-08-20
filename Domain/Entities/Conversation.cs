using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAll.Domain.Entities
{
    public class Conversation
    { 

        [Key]
        public int Id { get; set; }


        // Number value
        [Required]
        public int ConversationTypeId { get; set; }

        // Memory object that's EF Core fill when use include
        [ForeignKey(nameof(ConversationTypeId))]
        public ConversationType ConversationType { get; set; } = null!;

        [MaxLength(200)]
        public string? Title { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        

    }
}
