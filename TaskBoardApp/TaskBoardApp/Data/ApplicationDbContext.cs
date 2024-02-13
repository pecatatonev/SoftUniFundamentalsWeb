using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Configuration;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
          .Entity<Models.Task>()
          .HasOne(t => t.Board)
          .WithMany(b => b.Tasks)
          .HasForeignKey(t => t.BoardId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BoardConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}