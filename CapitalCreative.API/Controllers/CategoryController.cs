using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CapitalCreative.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryRequest request)
        {
            var result = await _unitOfWork.Category.AddAsync(new Category
            {
                Name = request.Name
            });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Category.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Category.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            var result = await _unitOfWork.Category.UpdateAsync(new Category
            {
                Id = request.Id,
                Name = request.Name
            });

            return Ok(result);
        }
    }
}