﻿using CapitalCreative.API.Models.Data;
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
    }
}