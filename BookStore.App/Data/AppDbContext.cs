using BookStore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
             
    }
        public DbSet<Models.Book> Books { get; set; }
        public DbSet <Models.Author> Authors { get; set;}

    }
}
