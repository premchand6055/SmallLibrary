using Microsoft.EntityFrameworkCore;
using SmallLibrary.Models;

namespace SmallLibrary.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
