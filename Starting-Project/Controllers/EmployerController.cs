using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Test(int testId)
        {
            return Ok(_employerService.Test(testId));
        }

        [HttpPost]
        public IActionResult AddEmployer(Employer employer)
        {
            employer.Id = Guid.NewGuid().ToString();
            _employerService.InsertEmployerAsync(employer);
            return Ok();

        }
    }
}
