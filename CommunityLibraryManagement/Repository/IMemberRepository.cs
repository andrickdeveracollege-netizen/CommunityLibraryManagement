
using CommunityLibraryManagement.Models.DOMAIN;

namespace CommunityLibraryManagement.Repository
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Members>> GetAllAsync();
        Task<Members?> GetByIdAsync(int id);
        Task<Members> AddAsync(Members member);
        Task UpdateAsync(Members member);
        Task DeleteAsync(Members member);
    }
}
