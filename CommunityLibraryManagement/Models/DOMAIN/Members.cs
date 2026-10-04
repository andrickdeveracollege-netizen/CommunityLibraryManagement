namespace CommunityLibraryManagement.Models.DOMAIN
{
    public class Members
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string MembershipType { get; set; } = default!;
        public DateTime DateJoined { get; set; }
        public bool IsActive { get; set; }
    }
}
