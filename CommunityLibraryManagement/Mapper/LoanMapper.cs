using CommunityLibraryManagement.Models.DOMAIN;
using CommunityLibraryManagement.Models.DTO;
namespace CommunityLibraryManagement.Mapper
{
    public static class LoanMapper
    {
        public static LoanDto ToDto(Loan loan)
        {
            string status = loan.Status;

            if (loan.ReturnedDate == null && DateTime.Now > loan.DueDate)
            {
                status = "Overdue";
            }

            return new LoanDto
            {
                Id = loan.Id,
                BookId = loan.BookId,
                MemberId = loan.MemberId,
                BookTitle = loan.Book?.Title ?? string.Empty,
                MemberName = loan.Member?.FullName ?? string.Empty,
                BorrowedDate = loan.BorrowedDate,
                DueDate = loan.DueDate,
                ReturnedDate = loan.ReturnedDate,
                Status = status
            };
        }
    }
}
