using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapitalCreative.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) => _CategoryRepository = categoryRepository;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryRequest request)
        {
            var result = await _CategoryRepository.AddAsync(new Category
            {
                Name = request.Name
            });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _CategoryRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _CategoryRepository.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            var result = await _CategoryRepository.UpdateAsync(new Category
            {
                Id = request.Id,
                Name = request.Name
            });

            return Ok(result);
        }
    }
}