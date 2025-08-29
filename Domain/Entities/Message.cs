using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAll.Domain.Entities
{
    public class Message
    {

        [Key]
        public int Id { get; set; }

        // Relation with conversation
        [Required]
        public int ConversationId { get; set; }

        [ForeignKey(nameof(ConversationId))]
        public Conversation Conversation { get; set; } = null!;

        // Relation with user
        public int SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; } = null!;


        // Content of the message
        [MaxLength(2000)]
        public string? Content { get; set; }





    }
}
