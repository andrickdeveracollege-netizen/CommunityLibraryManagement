
﻿using CommunityLibraryManagement.Models.DOMAIN;

namespace CommunityLibraryManagement.Repository
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task<IEnumerable<Loan>> GetByMemberIdAsync(int memberId);
        Task<int> CountActiveLoansByMemberAsync(int memberId);
        Task<Loan> AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
    }
}
