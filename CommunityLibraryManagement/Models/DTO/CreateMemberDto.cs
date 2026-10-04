namespace CommunityLibraryManagement.Models.DTO
{
    public class CreateMemberDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string MembershipType { get; set; } = default!;
        public DateTime DateJoined { get; set; }
        public bool IsActive { get; set; }
    }
}
