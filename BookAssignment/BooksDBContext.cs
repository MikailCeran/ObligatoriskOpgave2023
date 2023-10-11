using Microsoft.EntityFrameworkCore;

namespace BookAssignment
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options) { }

        public DbSet<Book>Books { get; set; }
    }
}

