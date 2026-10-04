using CommunityLibraryManagement.Mapper;
using CommunityLibraryManagement.Models.DOMAIN;
using CommunityLibraryManagement.Models.DTO;
using CommunityLibraryManagement.Repository;
using CommunityLibraryManagement.Respiratory;
using CommunityLibraryManagement.Service;

namespace CommunityLibraryManagement.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public LoanService(
            ILoanRepository loanRepository,
            IBookRepository bookRepository,
            IMemberRepository memberRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<LoanDto>> GetAllAsync()
        {
            var loans = await _loanRepository.GetAllAsync();

            return loans.Select(LoanMapper.ToDto);
        }

        public async Task<LoanDto?> GetByIdAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);

            if (loan == null)
            {
                return null;
            }

            return LoanMapper.ToDto(loan);
        }

        public async Task<IEnumerable<LoanDto>> GetByMemberIdAsync(int memberId)
        {
            var loans = await _loanRepository.GetByMemberIdAsync(memberId);

            return loans.Select(LoanMapper.ToDto);
        }

        public async Task<(LoanDto? Loan, string? Error, int StatusCode)> BorrowAsync(
            AddLoanDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(dto.BookId);

            if (book == null)
            {
                return (null, "Book not found.", 404);
            }

            var member = await _memberRepository.GetByIdAsync(dto.MemberId);

            if (member == null)
            {
                return (null, "Member not found.", 404);
            }

            if (!member.IsActive)
            {
                return (null, "Inactive members cannot borrow books.", 409);
            }

            if (book.AvailableCopies <= 0)
            {
                return (null, "No available copies of this book.", 409);
            }

            var activeLoans =
                await _loanRepository.CountActiveLoansByMemberAsync(dto.MemberId);

            if (activeLoans >= 3)
            {
                return (null, "Member already has the maximum of 3 active loans.", 409);
            }

            var borrowedDate = DateTime.Now;

            var loan = new Loan
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowedDate = borrowedDate,
                DueDate = borrowedDate.AddDays(7),
                ReturnedDate = null,
                Status = "Borrowed"
            };

            book.AvailableCopies--;

            await _bookRepository.UpdateAsync(book);

            var result = await _loanRepository.AddAsync(loan);

            result.Book = book;
            result.Member = member;

            return (LoanMapper.ToDto(result), null, 201);
        }

        public async Task<(LoanDto? Loan, string? Error, int StatusCode)> ReturnAsync(
            int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);

            if (loan == null)
            {
                return (null, "Loan not found.", 404);
            }

            if (loan.ReturnedDate != null)
            {
                return (null, "This loan has already been returned.", 409);
            }

            var book = await _bookRepository.GetByIdAsync(loan.BookId);

            if (book == null)
            {
                return (null, "Book not found.", 404);
            }

            loan.ReturnedDate = DateTime.Now;
            loan.Status = "Returned";

            book.AvailableCopies++;

            await _bookRepository.UpdateAsync(book);
            await _loanRepository.UpdateAsync(loan);

            loan.Book = book;

            return (LoanMapper.ToDto(loan), null, 200);
        }
    }
}