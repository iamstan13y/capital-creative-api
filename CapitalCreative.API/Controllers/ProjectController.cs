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
                Description = request.Description,
                Location = request.Location,
                Date = request.Date
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
                Description = request.Description,
                Date = request.Date,
                Location = request.Location,
                Title = request.Title
            });

            _unitOfWork.SaveChanges();

            return Ok(result);
        }
    }
}