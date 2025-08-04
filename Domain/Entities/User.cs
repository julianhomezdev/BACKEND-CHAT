// This is the model for the user entity

using System.ComponentModel.DataAnnotations;

namespace ChatAll.Domain.Entities
{
    public class User
    {

        // Auto increment id pk
        [Key]
        public int id { get; set; }


        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string FirstName {  get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Last 4 digit code for email verification
        public int LastCode { get; set; } = 0;


    }
}
