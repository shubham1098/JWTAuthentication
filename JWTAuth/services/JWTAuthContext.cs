using JWTAuth.models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.services
{
    public class JWTAuthContext : DbContext
    {
        public JWTAuthContext(DbContextOptions<JWTAuthContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}