using API_eSIP.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
        }

    }
}
