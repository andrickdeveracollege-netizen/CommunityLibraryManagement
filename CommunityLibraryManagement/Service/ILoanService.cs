using CommunityLibraryManagement.Models.DTO;

namespace CommunityLibraryManagement.Service
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDto>> GetAllAsync();
        Task<LoanDto?> GetByIdAsync(int id);
        Task<IEnumerable<LoanDto>> GetByMemberIdAsync(int memberId);
        Task<(LoanDto? Loan, string? Error, int StatusCode)> BorrowAsync(AddLoanDto dto);
        Task<(LoanDto? Loan, string? Error, int StatusCode)> ReturnAsync(int id);
    }
}
