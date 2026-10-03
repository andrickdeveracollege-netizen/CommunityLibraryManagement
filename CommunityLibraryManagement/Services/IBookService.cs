using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace CommunityLibraryManagement.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task<BookDto> CreateAsync(AddBookDto dto);
        Task<BookDto?> UpdateAsync(int id, AddBookDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
