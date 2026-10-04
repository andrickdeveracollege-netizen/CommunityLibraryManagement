using CommunityLibraryManagement.Models.DATA;
using CommunityLibraryManagement.Models.DOMAIN;
using Microsoft.EntityFrameworkCore;
namespace CommunityLibraryManagement.Repository
{
        public class LoanRepository : ILoanRepository
        {
            private readonly AppDBContext _context;

            public LoanRepository(AppDBContext context)
        {
                _context = context;
            }

            public async Task<IEnumerable<Loan>> GetAllAsync()
            {
                return await _context.Loans
                    .Include(l => l.Book)
                    .Include(l => l.Member)
                    .AsNoTracking()
                    .ToListAsync();
            }

            public async Task<Loan?> GetByIdAsync(int id)
            {
                return await _context.Loans
                    .Include(l => l.Book)
                    .Include(l => l.Member)
                    .FirstOrDefaultAsync(l => l.Id == id);
            }

            public async Task<IEnumerable<Loan>> GetByMemberIdAsync(int memberId)
            {
                return await _context.Loans
                    .Include(l => l.Book)
                    .Include(l => l.Member)
                    .Where(l => l.MemberId == memberId)
                    .AsNoTracking()
                    .ToListAsync();
            }

            public async Task<int> CountActiveLoansByMemberAsync(int memberId)
            {
                return await _context.Loans
                    .CountAsync(l =>
                        l.MemberId == memberId &&
                        l.ReturnedDate == null);
            }

            public async Task<Loan> AddAsync(Loan loan)
            {
                await _context.Loans.AddAsync(loan);
                await _context.SaveChangesAsync();

                return loan;
            }

            public async Task UpdateAsync(Loan loan)
            {
                _context.Loans.Update(loan);
                await _context.SaveChangesAsync();
            }
    }
}
