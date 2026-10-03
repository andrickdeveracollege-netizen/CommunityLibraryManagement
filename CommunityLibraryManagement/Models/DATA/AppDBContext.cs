using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;

namespace CommunityLibraryManagement.Models.DATA
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
