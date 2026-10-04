using CommunityLibraryManagement.Models.DTO;

namespace CommunityLibraryManagement.Service
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllAsync();
        Task<MemberDto?> GetByIdAsync(int id);
        Task<MemberDto> CreateAsync(AddMemberDto dto);
        Task<MemberDto?> UpdateAsync(int id, AddMemberDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
