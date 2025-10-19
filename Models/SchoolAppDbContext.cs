using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Models
{
    public class SchoolAppDbContext : DbContext
    {
        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
