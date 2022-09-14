using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }
        public DbSet<Book>Books{ get; set; }
        public DbSet<Genre>Genres{ get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Genre>().Has
        //}
    }
}
