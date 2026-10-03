using WebApplication1.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibraryManagement.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        void Update(Book book);
        void Remove(Book book);
        Task<bool> ExistsAsync(int id);
    }
}
