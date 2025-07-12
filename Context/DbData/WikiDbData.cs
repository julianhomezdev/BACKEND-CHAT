using Microsoft.EntityFrameworkCore;
using WikiAll.Models;

namespace WikiAll.Context.DbData
{
    public class WikiDbData : DbContext
    {
        public WikiDbData(DbContextOptions<WikiDbData> options) : base(options)
        {
        }

        // Dbsets represents the tables
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Unique index
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Unique email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();    
        }
    }
}
