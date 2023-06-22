using API.Utility;
using API_eSIP.Contracts;
using API_eSIP.Models;
using API_eSIP.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace API_eSIP.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    public class EmployeeController : BaseController<Employee, EmployeeVM>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper<Employee, EmployeeVM> _mapper;


        public EmployeeController(IEmployeeRepository employeeRepository, IMapper<Employee, EmployeeVM> mapper) : base(employeeRepository, mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }

        
    }
}
