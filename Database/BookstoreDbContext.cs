using bookstore.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Database
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
        : base(options) { }

        public DbSet<BookEntity> BookEntities { get; set; }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>().HasData(
                new BookEntity { Id = Guid.Parse("3cf3308a-d801-4307-8c2e-79ed0b467d4d"), Title = "The Fellowship of the Ring" },
                new BookEntity { Id = Guid.Parse("9d981a6c-c173-4b6d-9209-293f571d1e25"), Title = "The Two Towers" },
                new BookEntity { Id = Guid.Parse("0e01c4ab-7cb9-4185-9744-9efd35129641"), Title = "The Return of the King" }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }
    }
}
