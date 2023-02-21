using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CapitalCreative.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductRequest request)
        {
            var result = await _unitOfWork.Product.AddAsync(new Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            });

            _unitOfWork.SaveChanges();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Product.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Product.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            var result = await _unitOfWork.Product.UpdateAsync(new Product
            {
                Id = request.Id,
                Name = request.Name,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Price = request.Price
            });

            _unitOfWork.SaveChanges();

            return Ok(result);
        }
    }
}