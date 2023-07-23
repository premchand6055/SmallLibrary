using Microsoft.EntityFrameworkCore;
using SmallLibrary.Models;

namespace SmallLibrary.DAL
{
    //DAL - Data Access Layer
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
