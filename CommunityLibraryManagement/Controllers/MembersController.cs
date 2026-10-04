using CommunityLibraryManagement.Models.DTO;
using CommunityLibraryManagement.Services;
using CommunityLibraryManagement.Models.DOMAIN;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;
        private readonly ILoanService _loanService;

        public MembersController(
            IMemberService service,
            ILoanService loanService)
        {
            _service = service;
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetById(int id)
        {
            var member = await _service.GetByIdAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> Create(AddMemberDto dto)
        {
            var member = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = member.Id },
                member);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MemberDto>> Update(
            int id,
            AddMemberDto dto)
        {
            var member = await _service.UpdateAsync(id, dto);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}/loans")]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetLoans(int id)
        {
            var member = await _service.GetByIdAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(await _loanService.GetByMemberIdAsync(id));
        }
    }
}