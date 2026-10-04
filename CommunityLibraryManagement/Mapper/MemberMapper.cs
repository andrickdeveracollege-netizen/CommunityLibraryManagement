using CommunityLibraryManagement.Models.DOMAIN;
using CommunityLibraryManagement.Models.DTO;
namespace CommunityLibraryManagement.Mapper

{
    public static class MemberMapper
    {
        public static MemberDto ToDto(Members member)
        {
            return new MemberDto
            {
                Id = member.Id,
                FullName = member.FullName,
                Email = member.Email,
                MembershipType = member.MembershipType,
                DateJoined = member.DateJoined,
                IsActive = member.IsActive
            };
        }

        public static Members ToEntity(AddMemberDto dto)
        {
            return new Members
            {
                FullName = dto.FullName,
                Email = dto.Email,
                MembershipType = dto.MembershipType,
                DateJoined = dto.DateJoined,
                IsActive = dto.IsActive
            };
        }
    }
}
