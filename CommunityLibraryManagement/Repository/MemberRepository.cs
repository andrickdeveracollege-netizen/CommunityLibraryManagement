using CommunityLibraryManagement.Models.DOMAIN;
using CommunityLibraryManagement.Models.DATA;
namespace CommunityLibraryManagement.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDBContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Members>> GetAllAsync()
        {
            return await _context.Members
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Members?> GetByIdAsync(int id)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Members> AddAsync(Members member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task UpdateAsync(Members member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Members member)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}
