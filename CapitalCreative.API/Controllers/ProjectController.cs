using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CapitalCreative.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProjectRequest request)
        {
            var result = await _unitOfWork.Project.AddAsync(new Project
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                DetailedDescription = request.DetailedDescription,
                DateCommissioned = request.DateCommissioned,
                ImageUrl = request.ImageUrl,
                Location = request.Location
            });

            _unitOfWork.SaveChanges();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Project.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Project.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectRequest request)
        {
            var result = await _unitOfWork.Project.UpdateAsync(new Project
            {
                Id = request.Id,
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Location = request.Location,
                DateCommissioned = request.DateCommissioned,
                DetailedDescription = request.DetailedDescription,
                ImageUrl = request.ImageUrl
            });

            _unitOfWork.SaveChanges();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Project.DeleteAsync(id);
            if (!result.Success) return NotFound(result);

            _unitOfWork.SaveChanges();

            return Ok(result);
        }
    }
}