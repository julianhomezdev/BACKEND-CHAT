using ChatAll.Domain.Entities;
using ChatAll.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatAll.Infraestructure.DbData
{
    public class ChatDb : DbContext
    {
        public ChatDb(DbContextOptions<ChatDb> options) : base(options)
        {
        }

        // Dbsets represents the tables
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();    
        }
    }
}
