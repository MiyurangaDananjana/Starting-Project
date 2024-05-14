using Microsoft.AspNetCore.Mvc;
using Starting_Project.Models.DTOs;
using Starting_Project.Models.Entities;
using Starting_Project.Services;

namespace Starting_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployer _employerService;

        public EmployerController(IEmployer employerService)
        {
            _employerService = employerService;
        }

        [HttpPost]
        public IActionResult AddEmployer(EmployerDTO employerDTO)
        {
            string id = Guid.NewGuid().ToString();

            // Map DTO to entity
            var employer = new Employer
            {
                Id = id,
                FirstName = employerDTO.FirstName,
                LastName = employerDTO.LastName,
                Email = employerDTO.Email,
                Nationality = employerDTO.Nationality,
                CurrentResidence = employerDTO.CurrentResidence,
                IdNumber = employerDTO.IdNumber,
                DateOfBirth = employerDTO.DateOfBirth,
                Gender = employerDTO.Gender,
                question = new Question
                {
                    Type = employerDTO.question.Type
                }
            };

            _employerService.InsertEmployerAsync(employer);
            return Ok("Succuss !");

        }

        [HttpGet]
        public async Task<IActionResult> GetEmployer()
        {
            var employers = await _employerService.GetEmployeeDetails();
            return Ok(employers);
        }
    }
}
