using CommunityLibraryManagement.Models.DATA;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibraryManagement.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDBContext _context;

        public BookRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Books.AnyAsync(b => b.Id == id);
        }
    }
}
