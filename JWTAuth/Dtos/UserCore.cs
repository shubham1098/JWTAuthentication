using System;

namespace JWTAuth.Dtos
{
    public class UserCore
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string UserRole { get; set; }
        // public DateTime DateCreated { get; set; }
    }
}