using System;
using System.ComponentModel.DataAnnotations;

namespace JWTAuth.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string UserRole { get; set; }
    }
}