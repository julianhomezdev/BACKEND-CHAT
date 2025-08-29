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
        //public DbSet<Email> Emails { get; set; }
        public DbSet<ConversationType> ConversationTypes { get; set; }

        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<ConversationMember> ConversationMembers { get; set; }

        public DbSet<Message> Messages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Fk config
            // Table conversations with a fk to ConversationTypes
            modelBuilder.Entity<Conversation>()
                .HasOne(c => c.ConversationType)
                .WithMany()
                .HasForeignKey(c => c.ConversationTypeId);

            modelBuilder.Entity<ConversationMember>()
                .HasOne(cm => cm.Conversation)
                .WithMany()
                .HasForeignKey(cm => cm.ConversationId);

            modelBuilder.Entity<ConversationMember>()
                .HasOne(cm => cm.User)
                .WithMany()
                .HasForeignKey(cm => cm.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Conversation)
                .WithMany()
                .HasForeignKey(m => m.ConversationId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId);
           
            
          
        }
    }
}
