using Microsoft.EntityFrameworkCore;
using CommunityLibraryManagement.Models.DOMAIN;

namespace CommunityLibraryManagement.Models.DATA
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Members> Members => Set<Members>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
