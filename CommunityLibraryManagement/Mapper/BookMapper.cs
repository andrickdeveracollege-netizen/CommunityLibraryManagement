using CommunityLibraryManagement.Models.DTO;
using CommunityLibraryManagement.Models.DOMAIN;

namespace CommunityLibraryManagement.Mapper
{
    public static class BookMapper
    {
        public static BookDto ToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Category = book.Category,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies
            };
        }

        public static Book ToEntity(AddBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                Category = dto.Category,
                TotalCopies = dto.TotalCopies,
                AvailableCopies = dto.TotalCopies
            };
        }
    }
}