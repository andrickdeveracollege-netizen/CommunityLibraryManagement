using CommunityLibraryManagement.Models.DOMAIN.DTO;

namespace CommunityLibraryManagement.Service
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