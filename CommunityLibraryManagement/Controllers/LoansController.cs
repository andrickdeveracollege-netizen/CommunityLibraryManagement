using CommunityLibraryManagement.Models.DTO;
using CommunityLibraryManagement.Models.DOMAIN;
using CommunityLibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommunityLibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoansController(ILoanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetById(int id)
        {
            var loan = await _service.GetByIdAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDto>> Borrow(AddLoanDto dto)
        {
            var result = await _service.BorrowAsync(dto);

            if (result.Error != null)
            {
                return StatusCode(
                    result.StatusCode,
                    new { message = result.Error });
            }

            return StatusCode(
                201,
                result.Loan);
        }

        [HttpPost("{id}/return")]
        public async Task<ActionResult<LoanDto>> Return(int id)
        {
            var result = await _service.ReturnAsync(id);

            if (result.Error != null)
            {
                return StatusCode(
                    result.StatusCode,
                    new { message = result.Error });
            }

            return Ok(result.Loan);
        }
    }
}
