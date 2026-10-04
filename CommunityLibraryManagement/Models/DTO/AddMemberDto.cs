namespace CommunityLibraryManagement.Models.DTO
{
    public class AddMemberDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MembershipType { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }
        public bool IsActive { get; set; }
    }
}
