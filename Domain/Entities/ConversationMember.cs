using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAll.Domain.Entities
{
    public class ConversationMember
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public int ConversationId { get; set; }

        // Relation with Conversation
        [ForeignKey(nameof(ConversationId))]
        public Conversation Conversation { get; set; } = null!;

        // Relation with user
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;





    }
}
