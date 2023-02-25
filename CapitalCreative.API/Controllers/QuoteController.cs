using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CapitalCreative.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Quote.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Quote.FindAsync(id);
            if (!result.Success) return NotFound(result);
            
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Post(QuoteRequest request)
        {
            string appliances = string.Empty;
            request.Appliances!.ForEach(x =>
            {
                appliances += $"{x}, ";
            });
            
            var result = await _unitOfWork.Quote.AddAsync(new Quote
            {
                Address = request.Address,
                Appliances = appliances,
                HowDidYouHearAboutUs = request.HowDidYouHearAboutUs,
                Budget = request.Budget,
                ChoosingTheRightSystem = request.ChoosingTheRightSystem,
                Email = request.Email,
                FullName = request.FullName,
                OtherInformation = request.OtherInformation,
                PhoneNumber = request.PhoneNumber,
                RoofPitchedOrFlat = request.RoofPitchedOrFlat,
                RoofType = request.RoofType,
                SystemRequirements = request.SystemRequirements
            });
            
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}