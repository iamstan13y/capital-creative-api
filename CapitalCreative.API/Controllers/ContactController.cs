using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CapitalCreative.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Contact.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Contact.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}