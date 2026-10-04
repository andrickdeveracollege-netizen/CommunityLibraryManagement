using System.Linq;
using CommunityLibraryManagement.Models.DTO;
using CommunityLibraryManagement.Respiratory;
using WebApplication1.Mapper;

namespace CommunityLibraryManagement.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return books.Select(BookMapper.ToDto);
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            return BookMapper.ToDto(book);
        }

        public async Task<BookDto> CreateAsync(AddBookDto dto)
        {
            var book = BookMapper.ToEntity(dto);
            var result = await _repository.AddAsync(book);

            return BookMapper.ToDto(result);
        }

        public async Task<BookDto?> UpdateAsync(int id, AddBookDto dto)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.Category = dto.Category;

            int borrowedCopies = book.TotalCopies - book.AvailableCopies;

            book.TotalCopies = dto.TotalCopies;
            book.AvailableCopies = dto.TotalCopies - borrowedCopies;

            if (book.AvailableCopies < 0)
            {
                book.AvailableCopies = 0;
            }

            await _repository.UpdateAsync(book);

            return BookMapper.ToDto(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return false;
            }

            await _repository.DeleteAsync(book);

            return true;
        }
    }
}
