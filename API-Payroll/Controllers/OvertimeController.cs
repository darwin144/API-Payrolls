using API_eSIP.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class OvertimeController : Controller
    {
        private readonly IEmployeeOvertimeRepository repository;

        public OvertimeController(IEmployeeOvertimeRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
        }

    }
}
