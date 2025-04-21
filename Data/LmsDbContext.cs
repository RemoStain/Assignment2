using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Data
{
    public class LmsDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public LmsDbContext(DbContextOptions<LmsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: setup relationships
            modelBuilder.Entity<Borrowing>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Borrowing>()
                .HasOne<Reader>()
                .WithMany()
                .HasForeignKey(b => b.ReaderId);
        }
    }
}
