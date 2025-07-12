// This is the model for the user entity

using System.ComponentModel.DataAnnotations;

namespace WikiAll.Models
{
    public class User
    {

        // Auto increment id pk
        [Key]
        public int id { get; set; }


        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string FirstName {  get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }   


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
