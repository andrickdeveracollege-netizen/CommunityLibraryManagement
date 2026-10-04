using CommunityLibraryManagement.Mapper;
using CommunityLibraryManagement.Models.DTO;
using CommunityLibraryManagement.Repository;
using CommunityLibraryManagement.Service;

namespace CommunityLibraryManagement.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MemberDto>> GetAllAsync()
        {
            var members = await _repository.GetAllAsync();

            return members.Select(MemberMapper.ToDto);
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var member = await _repository.GetByIdAsync(id);

            if (member == null)
            {
                return null;
            }

            return MemberMapper.ToDto(member);
        }

        public async Task<MemberDto> CreateAsync(AddMemberDto dto)
        {
            var member = MemberMapper.ToEntity(dto);

            var result = await _repository.AddAsync(member);

            return MemberMapper.ToDto(result);
        }

        public async Task<MemberDto?> UpdateAsync(int id, AddMemberDto dto)
        {
            var member = await _repository.GetByIdAsync(id);

            if (member == null)
            {
                return null;
            }

            member.FullName = dto.FullName;
            member.Email = dto.Email;
            member.MembershipType = dto.MembershipType;
            member.DateJoined = dto.DateJoined;
            member.IsActive = dto.IsActive;

            await _repository.UpdateAsync(member);

            return MemberMapper.ToDto(member);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _repository.GetByIdAsync(id);

            if (member == null)
            {
                return false;
            }

            await _repository.DeleteAsync(member);

            return true;
        }
    }
}